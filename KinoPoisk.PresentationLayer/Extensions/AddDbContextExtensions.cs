using KinoPoisk.DataAccessLayer;
using KinoPoisk.DomainLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace KinoPoisk.PresentationLayer.Extensions {
    public static class AddDbContextExtensions {
        public static void AddDbConnection(this IServiceCollection services, string connectionString) {
            services.AddDbContext<ApplicationDbContext>(options => {
                options.UseSqlServer(connectionString);
            });
        }
    }
}
