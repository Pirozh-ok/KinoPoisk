using KinoPoisk.DomainLayer;
using KinoPoisk.DomainLayer.DTOs.TokensDTO;
using KinoPoisk.DomainLayer.Entities;
using KinoPoisk.DomainLayer.Intarfaces.Services;
using KinoPoisk.DomainLayer.Resources;
using KinoPoisk.DomainLayer.Settings;
using KinoPoisk.PresentationLayer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace KinoPoisk.BusinessLogicLayer.Services.Implementations {
    public class TokenService : ITokenService {
        private readonly IOptions<JwtSettings> _jwtSettings;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUnitOfWork _unitOfWork;

        public TokenService(
            IOptions<JwtSettings> jwtSettings,
            UserManager<ApplicationUser> userManager,
            IUnitOfWork unitOfWork) {
            _userManager = userManager; 
            _jwtSettings = jwtSettings;
            _unitOfWork = unitOfWork;
           ;
        }

        public async Task<string> GenerateAccessToken(ApplicationUser user) {
            var tokenHandler = new JwtSecurityTokenHandler();

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Value.Key));
            var claims = await GetClaimsByUser(user); 

            var tokenDescription = new SecurityTokenDescriptor {
                Issuer = _jwtSettings.Value.Issuer,
                Audience = _jwtSettings.Value.Audience,
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddSeconds(int.Parse(_jwtSettings.Value.TokenValidityInSecond)),
                SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescription);

            return tokenHandler.WriteToken(token);
        }

        public async Task<Result> GetNewTokens(string jwtToken, string refresh) {
            if (string.IsNullOrEmpty(jwtToken) || string.IsNullOrEmpty(refresh)) {
                return Result.Fail(UserResource.InvalidAccessOrRefreshToken);
            }

            var user = await _unitOfWork.GetRepository<ApplicationUser>()
                .GetByFilter(x => x.RefreshToken == refresh);

            if (user is null) {
                return Result.Fail(UserResource.InvalidAccessOrRefreshToken);
            }

            if (user.RefreshTokenExpiryDate < DateTime.Now) {
                return Result.Fail(UserResource.InvalidAccessOrRefreshToken);
            }

            var newRefreshToken = GenerateRefreshToken();
            var newAccessToken = await GenerateAccessToken(user);

            user.RefreshToken = newRefreshToken.Token;
            user.RefreshTokenExpiryDate = newRefreshToken.ExpirationDate;
            await _userManager.UpdateAsync(user);

            return Result.Ok(
                new TokensDTO {
                    AccessToken = newAccessToken,
                    RefreshToken = newRefreshToken.Token
                });
        }

        public RefreshTokenDTO GenerateRefreshToken() {
            return new RefreshTokenDTO() {
                Token = Guid.NewGuid().ToString(),
                ExpirationDate = DateTime.UtcNow.AddDays(_jwtSettings.Value.RefreshTokenValidityInDays)
            };
        }

        private async Task<List<Claim>> GetClaimsByUser(ApplicationUser user) {
            var userRoles = await _userManager.GetRolesAsync(user);

            var authClaims = new List<Claim> {
                    new Claim(JwtRegisteredClaimNames.Jti, user.Id.ToString()),
            };

            foreach (var userRole in userRoles) {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole));
            }

            return authClaims; 
        }
    }
}
