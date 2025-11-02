using GD.Sabre.Common.Core.Models.Options;
using GD.Sabre.Common.Core.Factories;
using Microsoft.Extensions.Options;
using System.Text.Json;
using GD.Sabre.Common.Service.Session;

namespace GD.Sabre.Common.Core.Models;

public class SessionState
{
    public string? conversationId = null;
    public string? sessionToken = null;
    public string? pseudoCityCode = null;

    private List<SabreSessionRequestHeader> sabreRequests = new List<SabreSessionRequestHeader>();
    public DateTime LastAccess { get; set; } = DateTime.Now;

    public int RequestCount { get => sabreRequests.Count; }
    public SabreSessionRequestHeader CreateNewRequestHeader(IRequestHeaderBuilderFactory requestHeaderBuilderFactory, IOptions<SabreServicesOptions> options)
    {
        var requestHeaders = new SabreSessionRequestHeader(requestHeaderBuilderFactory.Create()
        .WithToken(sessionToken ?? "")
            .WithConversationId(conversationId ?? "")
            .WithCPAId(pseudoCityCode ?? "")
            .WithMessageId(Guid.NewGuid().ToString()));

        AddSession(requestHeaders);
        LastAccess = DateTime.Now;
        requestHeaders.SecurityToken = sessionToken ?? string.Empty;
        return requestHeaders;
    }
    private void AddSession(SabreSessionRequestHeader session)
    {
        session.SessionDisposed += (sender, e) => sabreRequests.Remove(session);
        sabreRequests.Add(session);
    }
}

public class SessionItem
{
    public SessionType Scope { get; internal set; } = SessionType.None;
    public string ScopedType { get => Scope.ToString(); }

    public string SessionId { get; init; } = Guid.NewGuid().ToString();
    public string? SessionToken { get; internal set; } = string.Empty;
    public int SessionCount { get; set; } = 0;
    public DateTime LastAccess { get; set; } = DateTime.UtcNow;
    public DateTime Expires { get; set; } = DateTime.UtcNow.AddMinutes(10);
    public string PseudoCityCode { get; set; } = string.Empty;
    public int Status { get; set; } = 0; // 0=Available, 1=InUse

    public SessionItem() { }

    public SessionItem(int status, string token, string pcc, SessionType scope)
    {
        Status = status;
        SessionToken = token;
        PseudoCityCode = pcc;
        Scope = scope;
    }


    public SessionItem Clone()
    {
        var json = JsonSerializer.Serialize(this);

        return JsonSerializer.Deserialize<SessionItem>(json);
    }



}
