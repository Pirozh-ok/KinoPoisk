using KinoPoisk.DataAccess;
using KinoPoisk.DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace KinoPoisk.PresentationLayer.Extensions {
    public static class AddDbContextExtensions {
        public static void AddDbConnection(this IServiceCollection services, string connectionString) {
            services.AddDbContext<ApplicationDbContext>(options => {
                options.UseSqlServer(connectionString);
            })
                .AddIdentity<ApplicationUser, ApplicationRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>(); 
        }
    }
}
