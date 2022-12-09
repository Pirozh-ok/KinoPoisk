using KinoPoisk.DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KinoPoisk.DataAccessLayer.Configurations {
    internal class ContentConfig : IEntityTypeConfiguration<Content> {
        public void Configure(EntityTypeBuilder<Content> builder) {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(x => x.Type)
                .IsRequired();

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(Constants.MaxLenOfName);

            builder.Property(x => x.Path)
                .IsRequired()
                .HasMaxLength(Constants.MaxLenOfPath);
        }
    }
}
