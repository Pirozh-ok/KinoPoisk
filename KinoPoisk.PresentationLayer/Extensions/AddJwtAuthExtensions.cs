using KinoPoisk.BusinessLogicLayer.Services.Implementations;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace KinoPoisk.PresentationLayer.Extensions {
    public static class AddAuthExtensions {
        public static void AddJwtAuth(this IServiceCollection services, IConfiguration configuration) {
            {
                services.AddAuthentication(config => {
                    config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    config.DefaultScheme= JwtBearerDefaults.AuthenticationScheme;
                })
                    .AddJwtBearer(config => {
                        config.TokenValidationParameters = new TokenValidationParameters {
                            ValidIssuer = configuration["JwtBearerSettings:Issuer"],
                            ValidAudience = configuration["JwtBearerSettings:Audience"],
                            ClockSkew = TimeSpan.Zero,
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtBearerSettings:Key"]))
                        }; 
                    });

                services.Configure<DataProtectionTokenProviderOptions>(options =>
                {
                    options.TokenLifespan = TimeSpan.FromDays(int.Parse(configuration["JwtBearerSettings:ConfirmEmailTokenValidityInDay"]));
                });

                services.AddScoped<ITokenService, TokenService>(); 
            }
        }
    }
}
