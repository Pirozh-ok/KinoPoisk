using KinoPoisk.DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KinoPoisk.DataAccessLayer.Configurations {
    internal class CreatorMovieConfig : IEntityTypeConfiguration<CreatorMovie> {
        public void Configure(EntityTypeBuilder<CreatorMovie> builder) {
            builder.HasKey(x => new { x.CreatorId, x.MovieId });
        }
    }
}
