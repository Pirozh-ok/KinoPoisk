using KinoPoisk.DomainLayer;
using KinoPoisk.DomainLayer.DTOs.TokensDTO;
using KinoPoisk.DomainLayer.Entities;
using KinoPoisk.DomainLayer.Resources;
using KinoPoisk.PresentationLayer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace KinoPoisk.BusinessLogicLayer.Services.Implementations {
    public class TokenService : ITokenService {
        private string _key;
        private string _issuer;
        private string _audience;
        private string _tokenValidityInSecond;
        private string _refreshTokenValidityInDays; 
        private UserManager<ApplicationUser> _userManager; 

        public TokenService(IConfiguration configuration, UserManager<ApplicationUser> userManager) {
            _key = configuration["JwtBearer:Key"];
            _issuer = configuration["JwtBearer:Issuer"];
            _audience = configuration["JwtBearer:Audience"];
            _tokenValidityInSecond = configuration["JwtBearer:TokenValidityInSecond"];
            _refreshTokenValidityInDays = configuration["JwtBearer:RefreshTokenValidityInDays"];
            _userManager = userManager; 
        }

        public async Task<string> GenerateAccessToken(ApplicationUser user) {
            var tokenHandler = new JwtSecurityTokenHandler();

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_key));
            var claims = await GetClaimsByUser(user); 

            var tokenDescription = new SecurityTokenDescriptor {
                Issuer = _issuer,
                Audience = _audience,
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddSeconds(int.Parse(_tokenValidityInSecond)),
                SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescription);

            return tokenHandler.WriteToken(token);
        }

        public async Task<Result> GetNewTokens(string jwtToken, string refresh) {
            if (string.IsNullOrEmpty(jwtToken) || string.IsNullOrEmpty(refresh)) {
                return new ErrorResult(new List<string> { UserResource.InvalidAccessOrRefreshToken });
            }

            var id = GetUserIdByJwt(jwtToken);

            if (string.IsNullOrEmpty(id)) {
                return new ErrorResult(new List<string> { UserResource.InvalidAccessOrRefreshToken });
            }

            var user = await _userManager.FindByIdAsync(id);

            if(user is null || user.RefreshToken != refresh || user.RefreshTokenExpiryDate < DateTime.Now ) {
                return new ErrorResult(new List<string> { UserResource.InvalidAccessOrRefreshToken });
            }

            var newRefreshToken = GenerateRefreshToken();
            var newAccessToken = await GenerateAccessToken(user);

            user.RefreshToken = newRefreshToken.Token;
            user.RefreshTokenExpiryDate = newRefreshToken.ExpirationDate; 
            await _userManager.UpdateAsync(user);

            return new SuccessResult<TokensDTO>(new TokensDTO {
                AccessToken = newAccessToken,
                RefreshToken = newRefreshToken.Token
            });
        }

        public RefreshTokenDTO GenerateRefreshToken() {
            return new RefreshTokenDTO() {
                Token = Guid.NewGuid().ToString(),
                ExpirationDate = DateTime.Now.AddDays(int.Parse(_refreshTokenValidityInDays))
            };
        }

        private async Task<List<Claim>> GetClaimsByUser(ApplicationUser user) {
            var userRoles = await _userManager.GetRolesAsync(user);

            var authClaims = new List<Claim> {
                    new Claim(JwtRegisteredClaimNames.Jti, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Email, user.Email)
             };

            foreach (var userRole in userRoles) {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole));
            }

            return authClaims; 
        }

        private string GetUserIdByJwt(string jwtToken) {
            try {
                var handler = new JwtSecurityTokenHandler();
                var jwtSecurityToken = handler.ReadJwtToken(jwtToken);
                var claim = jwtSecurityToken.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Jti);
                return claim?.Value;
            }
            catch {
                return string.Empty; 
            }
        }
    }
}
