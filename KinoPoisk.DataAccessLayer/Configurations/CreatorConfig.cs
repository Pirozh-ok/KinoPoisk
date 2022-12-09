using KinoPoisk.DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KinoPoisk.DataAccessLayer.Configurations {
    internal class CreatorConfig : IEntityTypeConfiguration<Creator> {
        public void Configure(EntityTypeBuilder<Creator> builder) {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(x => x.FirstName)
                .IsRequired()
                .HasMaxLength(Constants.MaxLenOfName);

            builder.Property(x => x.FirstName)
               .IsRequired()
               .HasMaxLength(Constants.MaxLenOfName);

            builder.Property(x => x.LastName)
               .IsRequired()
               .HasMaxLength(Constants.MaxLenOfName);

            builder.Property(x => x.Patronymic)
               .HasMaxLength(Constants.MaxLenOfName)
               .HasDefaultValue(string.Empty);

            builder.Property(x => x.DateOfBirth)
                .IsRequired();

            builder
                .HasMany(x => x.CreatorsMovies)
                .WithOne(x => x.Creator)
                .HasForeignKey(x => x.CreatorId);
        }
    }
}
