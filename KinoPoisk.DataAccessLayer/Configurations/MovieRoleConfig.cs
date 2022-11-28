using KinoPoisk.DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KinoPoisk.DataAccessLayer.Configurations {
    internal class MovieRoleConfig : IEntityTypeConfiguration<MovieRole> {
        public void Configure(EntityTypeBuilder<MovieRole> builder) {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasData(
                new MovieRole {
                    Id = Guid.NewGuid(),
                    Name = "Director"
                },
                new MovieRole {
                    Id = Guid.NewGuid(),
                    Name = "Actors"
                },
                new MovieRole {
                    Id = Guid.NewGuid(),
                    Name = "Composer"
                },
                new MovieRole {
                    Id = Guid.NewGuid(),
                    Name = "ScreenWriters"
                },
                new MovieRole {
                    Id = Guid.NewGuid(),
                    Name = "Producers"
                },
                new MovieRole {
                    Id = Guid.NewGuid(),
                    Name = "Artists"
                },
                new MovieRole {
                    Id = Guid.NewGuid(),
                    Name = "Operators"
                },
                new MovieRole {
                    Id = Guid.NewGuid(),
                    Name = "Director"
                });
        }
    }
}
