using KinoPoisk.DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Identity.Client;

namespace KinoPoisk.DataAccessLayer.Configurations {
    internal class MovieConfig : IEntityTypeConfiguration<Movie> {
        public void Configure(EntityTypeBuilder<Movie> builder) {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Description)
                .HasDefaultValue(string.Empty)
                .HasMaxLength(500);

            builder.Property(x => x.DurationInMinutes)
                .IsRequired();

            builder.Property(x => x.BudgetInDollars)
                .IsRequired();

            builder.Property(x => x.WorldFeesInDollars)
                .IsRequired();

            builder.Property(x => x.PremiereDate)
                .IsRequired();

            builder
                .HasMany(x => x.Awards)
                .WithOne(x => x.Movie)
                .HasForeignKey(x => x.MovieId);

            builder
                .HasMany(x => x.Creators_Movies)
                .WithOne(x => x.Movie)
                .HasForeignKey(x => x.MovieId);

            builder
                .HasMany(x => x.Content)
                .WithOne(x => x.Movie)
                .HasForeignKey(x => x.MovieId);

            builder
                .HasMany(x => x.Ratings)
                .WithOne(x => x.Movie)
                .HasForeignKey(x => x.MovieId);
        }
    }
}
