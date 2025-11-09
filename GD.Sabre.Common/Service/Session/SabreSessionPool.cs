using GD.Sabre.Common.Core;
using GD.Sabre.Common.Core.Factories;
using GD.Sabre.Common.Core.Models;
using GD.Sabre.Common.Core.Models.Options;
using GD.Sabre.Common.Core.Reference;
using GD.Sabre.Common.Models;
using Microsoft.Extensions.Options;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace GD.Sabre.Common.Service.Session;

public class SabreSessionPool(
       IOptions<SabreServicesOptions> options,
       ISoapServiceFactory soapServiceFactory,
       IRequestHeaderBuilderFactory requestHeaderBuilderFactory)
       : SabreService(options, soapServiceFactory), ISabreSessionPool
{


    private readonly IOptions<SabreServicesOptions> _options =
        options ?? throw new ArgumentNullException(nameof(options));

    private int MaxAliveSessionsInPool => _options.MaxAliveSessionsInPool_PerPCC() ?? 1;
    private int MaxSimultaneousRequest => _options.MaxSimultaneousRequest_PerSession() ?? 1;
    private int SessionTimeout => _options.SessionTimeout() ?? 20;
    private bool UseSessionPool => _options.UseSessionPool() ?? true;
    private int MaxRetries => _options.MaxRetries() ?? 5;

    private bool _openSessionInProgress = false;

    private readonly IRequestHeaderBuilderFactory _requestHeaderBuilderFactory = requestHeaderBuilderFactory ??
                                                                                 throw new ArgumentNullException();

    //public static List<SessionState> sessionStates = new List<SessionState>();

    public static ConcurrentDictionary<string, SessionItem> _sessionPool = new();
    public static ConcurrentDictionary<string, string> _limitedPool = new();


    #region Transient Session
    public async Task<SabreResult<SessionItem>> GetTransientSession() => await GetTransientSession(_options?.Organization() ?? "CC61");

    public async Task<SabreResult<SessionItem>> GetTransientSession(string PCC)
    {
        var sabreSessionResult = await CreateSession(PCC);

        if (!sabreSessionResult.IsSuccess)
            return SabreResult<SessionItem>.Failure(sabreSessionResult.Error);

        if(string.IsNullOrEmpty(sabreSessionResult.Response?.Security?.BinarySecurityToken))
            return SabreResult<SessionItem>.Failure("GetTransientSession unable to create Sabre Sesion.");

        return SabreResult<SessionItem>.Success(new SessionItem(1, sabreSessionResult.Response.Security.BinarySecurityToken, PCC, SessionType.Transient));
       
    }
    #endregion

    #region Limited Session
    public async Task<SabreResult<SessionItem>> GetLimitedSession() => await GetLimitedSession(_options?.Organization() ?? "CC61");   
    public async Task<SabreResult<SessionItem>> GetLimitedSession(string PCC)
    {

        if(_limitedPool.Count(x=> x.Value == PCC) >= MaxAliveSessionsInPool)
            return SabreResult<SessionItem>.Failure("GetLimitedSession Session Limit Reached.");

        var sabreSessionResult  = await CreateSession(PCC);

        if (!sabreSessionResult.IsSuccess)
            return SabreResult<SessionItem>.Failure(sabreSessionResult.Error);

        if (string.IsNullOrEmpty(sabreSessionResult.Response?.Security?.BinarySecurityToken))
            return SabreResult<SessionItem>.Failure("GetLimitedSession unabe to create Sabre Session.");


        SessionItem sessionItem =  new(1, sabreSessionResult.Response.Security.BinarySecurityToken, PCC, SessionType.Limited);

        if (!_limitedPool.TryAdd(sessionItem.SessionToken!, sessionItem.PseudoCityCode))
        {
            await CloseSession(sessionItem.SessionToken!, sessionItem.PseudoCityCode);
            return SabreResult<SessionItem>.Failure("GetLimitedSession unable to add SessionItem.");
        }

        return SabreResult<SessionItem>.Success(sessionItem);
    }

    #endregion


    #region Pooled Session
    public async Task<SabreResult<SessionItem>> GetPooledSession() => await GetPooledSession(_options?.Organization() ?? "CC61");
    public async Task<SabreResult<SessionItem>> GetPooledSession(string PCC)
    {
        SessionItem? sessionItem = null;

        for(int i = 0; i < MaxRetries; i++)
        {

            sessionItem = await FindSessionPool(PCC);

            if (sessionItem is null)
            {
                await DelayService(2000);
                continue;
            }

            return SabreResult<SessionItem>.Success(sessionItem);

        }

        return SabreResult<SessionItem>.Failure("GetPooledSession unable to find an available session item");
    }


    private bool ExpiredToken(SessionItem session) => DateTime.UtcNow >= session.Expires;

    private bool CheckToken(Security? security) => !string.IsNullOrEmpty(security?.BinarySecurityToken);

    private async Task<SessionItem?> FindSessionPool(string PCC)
    {
        foreach (var session in _sessionPool.OrderBy(x=> x.Value.LastAccess).Where(x => x.Value.PseudoCityCode == PCC && x.Value.Status == 0))
        {
            if (await GrabSessionPoolItem(session.Value))
            {
                _sessionPool.TryGetValue(session.Key, out var sessionPoolItem);

                return sessionPoolItem;
            }
        }

        if(SessionPoolCount(PCC) < MaxAliveSessionsInPool)
        {
            return await AddSessionPool(PCC);
        }


        return null;
    }

    private async Task<SessionItem?> AddSessionPool(string PCC)
    {
        var sabreSessionResult = await CreateSession(PCC);

        if (!sabreSessionResult.IsSuccess)
            return null;

        if(!CheckToken(sabreSessionResult.Response?.Security))
            return null;

        string token = sabreSessionResult.Response!.Security!.BinarySecurityToken!;

        var sessionPoolItem = new SessionItem(1, token, PCC, SessionType.Pooled);

        if (!_sessionPool.TryAdd(sessionPoolItem.SessionId, sessionPoolItem))
        {
            await CloseSession(token, PCC);
            return null;
        }

        return sessionPoolItem;
    }

    private int SessionPoolCount(string PCC) => _sessionPool.Count(x=> x.Value.PseudoCityCode == PCC);


    private async Task<bool> GrabSessionPoolItem(SessionItem session)
    {

        var clone = session.Clone();
        clone.LastAccess = DateTime.UtcNow;
        clone.Status = 1;
        clone.SessionCount += 1;

        if(!ExpiredToken(session))
        {
            return _sessionPool.TryUpdate(session.SessionId, clone, session);
        }

        var sabreSessionResult = await CreateSession(session.PseudoCityCode);


        if (!sabreSessionResult.IsSuccess)
            return false;

        if (!CheckToken(sabreSessionResult.Response?.Security))
            return false;

        clone.SessionToken = sabreSessionResult!.Response!.Security!.BinarySecurityToken!;
        clone.Expires = DateTime.UtcNow;
        clone.LastAccess = DateTime.UtcNow;

        if (!_sessionPool.TryUpdate(session.SessionId, clone, session))
        {
            await CloseSession(clone.SessionToken, clone.PseudoCityCode);
            return false;
        }

        return true;
    }

   

    #endregion


    #region Release Session
    public virtual async Task DelayService(int millisecondsDelay)
    {
        await Task.Delay(millisecondsDelay);
    }

    public async Task<bool> ReleaseSession(Security? Security)
    {
        if (string.IsNullOrEmpty(Security?.BinarySecurityToken)) return false;

        var closeResult = await CloseSession(Security.BinarySecurityToken, _options?.Organization() ?? "CC61");
        
        return closeResult.Approved();
    }

    public async Task<bool> ReleaseSession(SessionItem sessionItem)
    {
        if (string.IsNullOrEmpty(sessionItem.SessionToken))
            return false;

        if (sessionItem.Scope == SessionType.Pooled)
        {
            var clone = sessionItem.Clone();
            clone.Status = 0;
            return _sessionPool.TryUpdate(sessionItem.SessionId, clone, sessionItem);
        }

        if (sessionItem.Scope == SessionType.Transient)
        {
            var closeResult = await CloseSession(sessionItem.SessionToken, sessionItem.PseudoCityCode);

            return closeResult.Approved();
        }

        if (sessionItem.Scope == SessionType.Limited)
        {
            var closeResult = await CloseSession(sessionItem!.SessionToken!, sessionItem.PseudoCityCode);

            return _limitedPool.TryRemove(sessionItem!.SessionToken!, out _) && closeResult.Approved();
        }

        return false;
    }

    #endregion


    #region Sabre Sessions
    public async Task<SabreResult<CreateSessionResponse>> CreateSession() => await CreateSession(_options?.Organization() ?? "CC61");

    public async Task<SabreResult<CreateSessionResponse>> CreateSession(string PCC)
    {
        try
        {
            var requestHeaders = _requestHeaderBuilderFactory.Create()
                 .WithBasicAuth(PCC)
                 .WithAction("SessionCreateRQ")
                 .WithService("SessionCreate")
                 .WithConversationId(Guid.NewGuid().ToString())
                 .WithCPAId(PCC)
                 .WithMessageId(Guid.NewGuid().ToString())
                 .Build();

            var requestBody = new SessionCreateRQ
            {
                POS = new SessionCreateRQPOS
                {
                    Source = new SessionCreateRQPOSSource
                    {
                        PseudoCityCode = PCC
                    }
                }
            };

            var _soapService = CreateSabreSoapService()
                .WithHeaders(requestHeaders)
                .WithPayload(requestBody);

            var openSessionResponseBody = await _soapService.PostAsync<SessionCreateRS>();
            var openSessionResponseSecurity = _soapService.GetLastResultHeader<Security>("Security");

            return SabreResult<CreateSessionResponse>.Success(new CreateSessionResponse
            {
                Security = openSessionResponseSecurity,
                SessionCreateRS = openSessionResponseBody
            });

        }
        catch (Exception ex)
        {
            return SabreResult<CreateSessionResponse>.Failure(ex);
        }
    }

    public async Task<SessionCloseRS> CloseSession(string token, string PCC)
    {
        try
        {
            var requestHeaders = _requestHeaderBuilderFactory.Create()

                 .WithBasicAuth(PCC)
                 .WithAction("SessionCloseRQ")
                 .WithService("SessionClose")
                 .WithToken(token)
                 .WithConversationId(Guid.NewGuid().ToString())
                 .WithCPAId(PCC)
                 .WithMessageId(Guid.NewGuid().ToString())
                 .Build();

            var requestBody = new SessionCloseRQ
            {
                POS = new SessionCloseRQPOS
                {
                    Source = new SessionCloseRQPOSSource
                    {
                        PseudoCityCode = PCC,

                    }
                },

            };

            var _soapService = CreateSabreSoapService()
                .WithHeaders(requestHeaders)
                .WithPayload(requestBody);

            var openSessionResponseBody = await _soapService.PostAsync<SessionCloseRS>();
            return openSessionResponseBody;
        }
        catch (Exception ex)
        {
            throw new Exception($"Partial submission failure: {ex.Message}");
        }
    }
    #endregion
}



//private async Task<SessionPoolItem?> GetSession(string PCC, int retries)
//{
//    SessionPoolItem? session = null;

//    var maxRetries = _options.MaxRetries() ?? 5; ;

//    CleanExpiredSessions();

//    if (UseSessionPool)
//        session = FindSession_Oldest_WithoutAnyRequest(PCC);

//    if (session == null)
//        session = await CreateNewSessionIfThereIsSpace(PCC);

//    if (session == null)
//        session = FindSession_With_FreeSpace(PCC);

//    if (session == null)
//    {
//        if (retries < maxRetries)
//        {
//            await DelayService(2000);
//            return await GetSession(PCC, retries + 1);
//        }
//        else
//            throw new Exception("No session available");
//    }

//    return session; //.CreateNewRequestHeader(_requestHeaderBuilderFactory, _options);
//}
//private IEnumerable<SessionPoolItem> sessionStates_ByPCC(string PCC) => _sessionPool.Where(s => s.Value.PseudoCityCode == PCC).Select(s => s.Value);

//private void CleanExpiredSessions()
//{


//    _sessionPool.Where(s => s.Value.LastAccess.AddMinutes(SessionTimeout) < DateTime.Now);
//}

//private SessionPoolItem? FindSession_Oldest_WithoutAnyRequest(string PCC)
//{
//    if (!(_sessionPool != null && sessionStates_ByPCC(PCC).Count() > 0)) return null;

//    var sess = _sessionPool.Where(s => s.Value.Status == 0 && s.Value.PseudoCityCode == PCC)?.OrderByDescending(s => s.Value.LastAccess).FirstOrDefault().Value;

//    if (sess == null) return null;

//    _sessionPool.TryUpdate()

//    sess.Status = 1;

//    return sess;
//}



//private async Task<SessionPoolItem?> CreateNewSessionIfThereIsSpace(string PCC)
//{
//    DateTime waitingTimeout = DateTime.Now.AddSeconds(40);
//    while (_openSessionInProgress && waitingTimeout > DateTime.Now)
//    {
//        await DelayService(300);
//    }
//    if (waitingTimeout < DateTime.Now)
//        throw new Exception("No session available");

//    if (sessionStates_ByPCC(PCC).Count() < MaxAliveSessionsInPool)
//    {
//        _openSessionInProgress = true;
//        try
//        {
//            var session = await OpenSession(PCC);
//            _sessionPool.TryAdd(session.SessionId, session);
//            return session;
//        }
//        catch (Exception ex)
//        {
//            throw new Exception($"Partial submission failure: {ex.Message}");
//        }
//        finally
//        {
//            _openSessionInProgress = false;
//        }
//    }
//    return null;
//}

//private SessionPoolItem? FindSession_With_FreeSpace(string PCC)
//{
//    if (!(_sessionPool != null && sessionStates_ByPCC(PCC).Count() > 0)) return null;

//    // return sessionStates_ByPCC(PCC).Where(s => s.RequestCount < MaxSimultaneousRequest)?.OrderBy(s => s.RequestCount).FirstOrDefault();
//    var sess = _sessionPool.Where(s => s.Value.Status == 0 && s.Value.PseudoCityCode == PCC)?.OrderByDescending(s => s.Value.LastAccess).FirstOrDefault().Value;

//    if (sess == null) return null;
//    sess.Status = 1;

//    return sess;
//}