using KinoPoisk.DomainLayer;
using KinoPoisk.DomainLayer.DTOs.TokensDTO;
using KinoPoisk.DomainLayer.Entities;
using System.Security.Claims;

namespace KinoPoisk.PresentationLayer {
    public interface ITokenService {
        Task<string> GenerateAccessToken(ApplicationUser user);
        public RefreshTokenDTO GenerateRefreshToken();
        Task<ServiceResult> GetNewTokens(string jwtToken, string refresh); 
    }
}
