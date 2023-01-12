using AutoMapper;
using KinoPoisk.DomainLayer.Mapping;

namespace KinoPoisk.PresentationLayer.Extensions {
    public static class AddMapperExtensions {
        public static void AddAutoMapper(this IServiceCollection services) {
            services.AddAutoMapper(typeof(GenreProfile), typeof(CountryProfile), typeof(UserProfile), typeof(AgeCategoryProfile)); 
        }
    }
}
