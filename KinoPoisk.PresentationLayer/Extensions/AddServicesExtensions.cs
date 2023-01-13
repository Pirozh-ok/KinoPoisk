using KinoPoisk.BusinessLogicLayer.Services.Implementations;
using KinoPoisk.DataAccessLayer;
using KinoPoisk.DomainLayer.Intarfaces.Services;

namespace KinoPoisk.PresentationLayer.Extensions {
    public static class AddServicesExtensions {
        public static void AddUserServices(this IServiceCollection services) {
            services.AddScoped<GenreService>();
            services.AddScoped<CountryService>();
            services.AddScoped<AgeCategoryService>();
            services.AddScoped<AwardService>();
            services.AddScoped<MovieRoleService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IRoleService, RoleServices>();
        }
    }
}
