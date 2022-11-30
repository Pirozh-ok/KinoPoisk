using KinoPoisk.BusinessLogicLayer.Services.Implementations;
using KinoPoisk.DataAccessLayer;
using KinoPoisk.DataAccessLayer.Repositories;
using KinoPoisk.DomainLayer.Intarfaces.Services;

namespace KinoPoisk.PresentationLayer.Extensions {
    public static class AddServicesExtensions {
        public static void AddUserServices(this IServiceCollection services) {
            services.AddScoped<IGenreService, GenreService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
