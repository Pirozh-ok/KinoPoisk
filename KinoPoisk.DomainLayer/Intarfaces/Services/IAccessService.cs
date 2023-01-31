using Microsoft.AspNetCore.Http;

namespace KinoPoisk.DomainLayer.Intarfaces.Services {
    public interface IAccessService {
        Guid GetUserIdFromRequest();
        bool IsAdministatorRequest();
        bool IsAuthorizedRequest();
        List<string> GetAuthorizeUserRoles();
        bool IsHasAccess(Guid userId);
        string GetSchemeFromRequest();
        string GetHostFromRequest();
    }
}
