using KinoPoisk.DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KinoPoisk.DataAccessLayer.Configurations {
    internal class RoleConfig : IEntityTypeConfiguration<ApplicationRole> {
        public void Configure(EntityTypeBuilder<ApplicationRole> builder) {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasMany(x => x.UserRoles)
                .WithOne(x => x.Role)
                .HasForeignKey(x => x.RoleId);

            builder.HasData(
                new ApplicationRole {
                    Id = Guid.NewGuid(),
                    Name = "Administrator"
                },
                new ApplicationRole {
                    Id = Guid.NewGuid(),
                    Name = "User"
                });
        }
    }
}
