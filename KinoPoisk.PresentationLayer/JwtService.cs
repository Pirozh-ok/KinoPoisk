using KinoPoisk.DomainLayer.DTOs.UserDTO;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace KinoPoisk.PresentationLayer {
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

        public string GenerateToken(JwtGenerateDTO userData) {
            var tokenHandler = new JwtSecurityTokenHandler();

            var claims = new List<Claim> {
                new Claim(JwtRegisteredClaimNames.Jti, userData.UserId.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, userData.Email),
                new Claim(JwtRegisteredClaimNames.Name, userData.UserName)
                };

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
