using KinoPoisk.DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KinoPoisk.DomainLayer.Configurations
{
    internal class MovieRoleConfig : IEntityTypeConfiguration<MovieRole>
    {
        public void Configure(EntityTypeBuilder<MovieRole> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
