using GD.Sabre.Common.Core.Models;
using GD.Sabre.Common.Core.Reference;

namespace GD.Sabre.Common.Service.Session;

public interface ISabreSessionPool
{

    Task<SessionItem> GetTransientSession();
    Task<SessionItem> GetTransientSession(string PCC);

    Task<SessionItem> GetLimitedSession();
    Task<SessionItem> GetLimitedSession(string PCC);
    Task<SessionItem> GetPooledSession();
    Task<SessionItem> GetPooledSession(string PCC);

    Task<bool> ReleaseSession(SessionItem session);
    Task<bool> ReleaseSession(Security? Security);

    Task<(SessionCreateRS? Response, Security? Security)?> CreateSession(string PCC);
    Task<(SessionCreateRS? Response, Security? Security)?> CreateSession();

    Task<SessionCloseRS> CloseSession(string token, string PCC);


}
