using KinoPoisk.DomainLayer.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using KinoPoisk.DomainLayer.Entities;

namespace KinoPoisk.DataAccessLayer {
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid> {
        public ApplicationDbContext() {
        }
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) {
        }

        public DbSet<AgeCategory> AgeCategories { get; set; }
        public DbSet<Award> Awards { get; set; }
        public DbSet<Content> Contents { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Creator> Creators { get; set; }
        public DbSet<CreatorMovie> CreatorsMovies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieRole> MovieRoles { get; set; }
        public DbSet<Rating> Ratings { get; set; }

        protected override void OnModelCreating(ModelBuilder builder) {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new AgeCategoryConfig());
            builder.ApplyConfiguration(new AwardConfig());
            builder.ApplyConfiguration(new ContentConfig());
            builder.ApplyConfiguration(new CountryConfig());
            builder.ApplyConfiguration(new CreatorConfig());
            builder.ApplyConfiguration(new CreatorMovieConfig());
            builder.ApplyConfiguration(new GenreConfig());
            builder.ApplyConfiguration(new MovieConfig());
            builder.ApplyConfiguration(new MovieRoleConfig());
            builder.ApplyConfiguration(new RatingConfig());
            builder.ApplyConfiguration(new UserConfig());
            builder.ApplyConfiguration(new RoleConfig());
        }
    }
}
