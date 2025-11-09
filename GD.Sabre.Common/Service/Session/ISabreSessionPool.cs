using GD.Sabre.Common.Core.Models;
using GD.Sabre.Common.Core.Reference;
using GD.Sabre.Common.Models;

namespace GD.Sabre.Common.Service.Session;

public interface ISabreSessionPool
{

    Task<SabreResult<SessionItem>> GetTransientSession();
    Task<SabreResult<SessionItem>> GetTransientSession(string PCC);

    Task<SabreResult<SessionItem>> GetLimitedSession();
    Task<SabreResult<SessionItem>> GetLimitedSession(string PCC);
    Task<SabreResult<SessionItem>> GetPooledSession();
    Task<SabreResult<SessionItem>> GetPooledSession(string PCC);

    Task<SabreResult<bool>> ReleaseSession(SessionItem session);
    Task<SabreResult<bool>> ReleaseSession(Security? Security);

    Task<SabreResult<CreateSessionResponse>> CreateSession(string PCC);
    Task<SabreResult<CreateSessionResponse>> CreateSession();

    Task<SessionCloseRS> CloseSession(string token, string PCC);


}
