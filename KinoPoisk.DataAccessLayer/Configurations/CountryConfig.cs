using KinoPoisk.DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KinoPoisk.DataAccessLayer.Configurations {
    internal class CountryConfig : IEntityTypeConfiguration<Country> {
        public void Configure(EntityTypeBuilder<Country> builder) {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder
                .HasMany(x => x.Users)
                .WithOne(x => x.Country)
                .HasForeignKey(x => x.CountryId);

            builder.HasData(
                new Country {
                    Id = Guid.NewGuid(),
                    Name = "Russia"
                },
                new Country {
                    Id = Guid.NewGuid(),
                    Name = "USA"
                },
                new Country {
                    Id = Guid.NewGuid(),
                    Name = "England"
                },
                new Country {
                    Id = Guid.NewGuid(),
                    Name = "France"
                },
                new Country {
                    Id = Guid.NewGuid(),
                    Name = "Germany"
                },
                new Country {
                    Id = Guid.NewGuid(),
                    Name = "China"
                },
                new Country {
                    Id = Guid.NewGuid(),
                    Name = "Japan"
                },
                new Country {
                    Id = Guid.NewGuid(),
                    Name = "Canada"
                },
                new Country {
                    Id = Guid.NewGuid(),
                    Name = "Finlyadnia"
                },
                new Country {
                    Id = Guid.NewGuid(),
                    Name = "Sweden"
                });
        }
    }
}
