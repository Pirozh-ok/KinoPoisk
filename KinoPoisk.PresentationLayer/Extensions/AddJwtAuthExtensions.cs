using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace KinoPoisk.PresentationLayer.Extensions {
    public static class AddAuthExtensions {
        public static void AddJwtAuth(this IServiceCollection services, IConfiguration configuration) {
            {
                services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(config => {
                        config.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters {
                            ValidIssuer = configuration["JwtBearer:Issuer"],
                            ValidAudience = configuration["JwtBearer:Audience"],
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtBearer:Key"]))
                        }; 
                    });

                services.AddScoped<IAuthService, JwtService>(); 
            }
        }
    }
}
