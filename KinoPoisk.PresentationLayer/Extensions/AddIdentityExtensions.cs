using KinoPoisk.DataAccessLayer;
using KinoPoisk.DomainLayer.Entities;
using Microsoft.AspNetCore.Identity;

namespace KinoPoisk.PresentationLayer.Extensions {
    public static class AddIdentityExtensions{
        public static void AddIdentitySettings(this IServiceCollection services) {
            services.AddIdentity<ApplicationUser, ApplicationRole>(opts => {
                opts.User.RequireUniqueEmail = true;
                opts.Password.RequiredLength = 6;
                opts.Password.RequireNonAlphanumeric = false;
                opts.Password.RequireLowercase = false;
                opts.Password.RequireUppercase = false;
                opts.Password.RequireDigit = false;
            })
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();
        }
    }
}
