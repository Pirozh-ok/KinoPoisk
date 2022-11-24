using KinoPoisk.DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KinoPoisk.DomainLayer.Configurations
{
    internal class Creator_MovieConfig : IEntityTypeConfiguration<Creator_Movie>
    {
        public void Configure(EntityTypeBuilder<Creator_Movie> builder)
        {
            builder.HasKey(x => new { x.CreatorId, x.MovieId }); 
        }
    }
}
