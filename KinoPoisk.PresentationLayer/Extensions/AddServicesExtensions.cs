using KinoPoisk.BusinessLogicLayer.Services.Implementations;
using KinoPoisk.DataAccessLayer;
using KinoPoisk.DomainLayer.Intarfaces.Services;

namespace KinoPoisk.PresentationLayer.Extensions {
    public static class AddServicesExtensions {
        public static void AddUserServices(this IServiceCollection services) {
            services.AddTransient<IGenreService, GenreService>();
            services.AddTransient<ICountryService, CountryService>();
            services.AddTransient<IAgeCategoryService, AgeCategoryService>();
            services.AddTransient<IAwardService, AwardService>();
            services.AddTransient<IMovieRoleService, MovieRoleService>();
            services.AddTransient<ICreatorService, CreatorService>();
            services.AddTransient<IContentService, ContentService>();
            services.AddTransient<IMovieService, MovieService>();
            services.AddTransient<RatingService>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<IRoleService, RoleServices>();
            services.AddTransient<IAccessService, AccessService>();
        }
    }
}
