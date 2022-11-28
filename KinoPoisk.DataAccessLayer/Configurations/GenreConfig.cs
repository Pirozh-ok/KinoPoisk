using KinoPoisk.DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KinoPoisk.DataAccessLayer.Configurations {
    internal class GenreConfig : IEntityTypeConfiguration<Genre> {
        public void Configure(EntityTypeBuilder<Genre> builder) {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasData(
                new Genre {
                    Id = Guid.NewGuid(),
                    Name = "Horror movie"
                },
                new Genre {
                    Id = Guid.NewGuid(),
                    Name = "Action movie"
                },
                new Genre {
                    Id = Guid.NewGuid(),
                    Name = "Fantasy"
                },
                new Genre {
                    Id = Guid.NewGuid(),
                    Name = "Thriller"
                },
                new Genre {
                    Id = Guid.NewGuid(),
                    Name = "Detective"
                },
                new Genre {
                    Id = Guid.NewGuid(),
                    Name = "Drama"
                },
                new Genre {
                    Id = Guid.NewGuid(),
                    Name = "Kids"
                },
                new Genre {
                    Id = Guid.NewGuid(),
                    Name = "Comedy"
                },
                new Genre {
                    Id = Guid.NewGuid(),
                    Name = "Adventures"
                },
                new Genre {
                    Id = Guid.NewGuid(),
                    Name = "War Film"
                },
                new Genre {
                    Id = Guid.NewGuid(),
                    Name = "Musical"
                });
        }
    }
}
