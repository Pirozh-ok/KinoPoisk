using KinoPoisk.BusinessLogicLayer.Services.Implementations;
using KinoPoisk.BusinessLogicLayer.Services.Interfaces;

namespace KinoPoisk.PresentationLayer.Extensions {
    public static class AddServicesExtensions {
        public static void AddUserServices(this IServiceCollection services) {
            services.AddScoped<IGenreService, GenreService>(); 
        }
    }
}
