using KinoPoisk.DataAccessLayer;
using KinoPoisk.DomainLayer.Intarfaces.Services;
using Microsoft.AspNetCore.Http;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace KinoPoisk.BusinessLogicLayer.Services.Implementations {
    public class AccessService : IAccessService {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AccessService(IHttpContextAccessor httpContextAccessor) {
            _httpContextAccessor = httpContextAccessor;
        }

        public Guid GetUserIdFromRequest() {
            return new Guid(_httpContextAccessor.HttpContext.User.Claims.First(x => x.Type == JwtRegisteredClaimNames.Jti)!.Value);
        }

        public bool IsAdministatorRequest() {
            return _httpContextAccessor.HttpContext.User.Claims.Any(x => x.Type == ClaimTypes.Role && x.Value == Constants.NameRoleAdmin);
        }

        public bool IsAuthorizedRequest() {
            if (_httpContextAccessor == null) {
                return false;
            }

            return _httpContextAccessor.HttpContext?.User?.Identity?.IsAuthenticated ?? false;
        }

        public List<string> GetAuthorizeUserRoles() => _httpContextAccessor.HttpContext.User.Claims
            .Where(x => x.Type == ClaimTypes.Role)
            .Select(x => x.Value)
            .ToList();

        public bool IsHasAccess(Guid userId) {
            var currentUserId = GetUserIdFromRequest();

            return currentUserId == userId
              || IsAdministatorRequest();
        }

        public string GetSchemeFromRequest() => _httpContextAccessor.HttpContext.Request.Scheme;
        public string GetHostFromRequest() => _httpContextAccessor.HttpContext.Request.Host.ToString();
    }
}
