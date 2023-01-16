using KinoPoisk.DataAccessLayer;
using Microsoft.AspNetCore.Http;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace KinoPoisk.BusinessLogicLayer {
    public static class AuthUserInfo {
        public static string? GetAuthUserId(IHttpContextAccessor accessor) => accessor.HttpContext.User.Claims
            .FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Jti)?.Value;

        public static bool IsHasAccess(string userId, IHttpContextAccessor accessor) {
            var currentUserId = GetAuthUserId(accessor);
            var currentUserRole = GetAuthUserRoles(accessor);

            return currentUserId == userId
              || currentUserRole.Contains(Constants.NameRoleAdmin);
        }

        public static List<string> GetAuthUserRoles(IHttpContextAccessor accessor) => accessor.HttpContext.User.Claims
            .Where(x => x.Type == ClaimTypes.Role)
            .Select(x => x.Value)
            .ToList();
    }
}
