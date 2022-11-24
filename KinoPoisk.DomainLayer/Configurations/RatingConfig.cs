using KinoPoisk.DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KinoPoisk.DomainLayer.Configurations
{
    internal class RatingConfig : IEntityTypeConfiguration<Rating>
    {
        public void Configure(EntityTypeBuilder<Rating> builder)
        {
            builder.HasKey(x => new { x.UserId, x.MovieId });

            builder.Property(x => x.MovieRating)
                .HasDefaultValue(0);

            builder.Property(x => x.Comment)
                .HasDefaultValue(string.Empty)
                .HasMaxLength(200); 
        }
    }
}
