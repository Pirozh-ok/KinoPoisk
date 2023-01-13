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
                .HasMaxLength(Constants.MaxLenOfName);

            builder.HasData(
                new MovieRole {
                    Id = Guid.NewGuid(),
                    Name = "Director"
                },
                new MovieRole {
                    Id = Guid.NewGuid(),
                    Name = "Actor"
                },
                new MovieRole {
                    Id = Guid.NewGuid(),
                    Name = "Composer"
                },
                new MovieRole {
                    Id = Guid.NewGuid(),
                    Name = "ScreenWriter"
                },
                new MovieRole {
                    Id = Guid.NewGuid(),
                    Name = "Producer"
                },
                new MovieRole {
                    Id = Guid.NewGuid(),
                    Name = "Artist"
                },
                new MovieRole {
                    Id = Guid.NewGuid(),
                    Name = "Operator"
                },
                new MovieRole {
                    Id = Guid.NewGuid(),
                    Name = "Editor"
                });
        }
    }
}
