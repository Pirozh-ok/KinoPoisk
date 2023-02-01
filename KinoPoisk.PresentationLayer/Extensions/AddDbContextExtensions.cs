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

        public static async Task SeedDataAsync(this IServiceCollection services) {
            var provider = services.BuildServiceProvider();
            var roleManager = provider.GetRequiredService<RoleManager<ApplicationRole>>();
            var userManager = provider.GetRequiredService<UserManager<ApplicationUser>>();
            
            var seedData = new SeedData(userManager, roleManager);
            await seedData.SeedRoles();
            await seedData.SeedUsers();
        }
    }
}
