using KinoPoisk.DomainLayer.DTOs.UserDTO;
using KinoPoisk.PresentationLayer;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace KinoPoisk.BusinessLogicLayer.Services.Implementations{
    public class JwtService : IAuthService {
        private string _key;
        private string _issuer;
        private string _audience;
        private string _tokenValidityInSecond;

        public JwtService(IConfiguration configuration) {
            _key = configuration["JwtBearer:Key"];
            _issuer = configuration["JwtBearer:Issuer"];
            _audience = configuration["JwtBearer:Audience"];
            _tokenValidityInSecond = configuration["JwtBearer:TokenValidityInSecond"];
        }

        public string GenerateToken(List<Claim> claims) {
            var tokenHandler = new JwtSecurityTokenHandler();

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_key));

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
    }
}
