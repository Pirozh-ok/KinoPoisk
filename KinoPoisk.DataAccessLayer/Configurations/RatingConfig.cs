using KinoPoisk.DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KinoPoisk.DataAccessLayer.Configurations {
    internal class RatingConfig : IEntityTypeConfiguration<Rating> {
        public void Configure(EntityTypeBuilder<Rating> builder) {
            builder.HasKey(x => new { x.UserId, x.MovieId });

            builder.Property(x => x.MovieRating)
                .HasDefaultValue(0);

            builder.Property(x => x.UpdateDate)
                 .HasDefaultValueSql("getdate()");

            builder.Property(x => x.Comment)
                .HasDefaultValue(string.Empty)
                .HasMaxLength(Constants.MaxLenOfComment);
        }
    }
}
