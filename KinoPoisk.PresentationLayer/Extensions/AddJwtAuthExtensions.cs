using KinoPoisk.BusinessLogicLayer.Services.Implementations;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace KinoPoisk.PresentationLayer.Extensions {
    public static class AddAuthExtensions {
        public static void AddJwtAuth(this IServiceCollection services, IConfigurationSection configuration) {
            {
                services.AddAuthentication(config => {
                    config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    config.DefaultScheme= JwtBearerDefaults.AuthenticationScheme;
                })
                    .AddJwtBearer(config => {
                        config.TokenValidationParameters = new TokenValidationParameters {
                            ValidIssuer = configuration["Issuer"],
                            ValidAudience = configuration["Audience"],
                            ClockSkew = TimeSpan.Zero,
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Key"])),
                            ValidateIssuer = true,
                            ValidateAudience = true,
                            ValidateLifetime = true,
                            ValidateIssuerSigningKey = true
                        }; 
                    });

                services.AddScoped<ITokenService, TokenService>(); 
            }
        }
    }
}
