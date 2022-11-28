using KinoPoisk.DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KinoPoisk.DataAccessLayer.Configurations {
    internal class AgeCategoryConfig : IEntityTypeConfiguration<AgeCategory> {
        public void Configure(EntityTypeBuilder<AgeCategory> builder) {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(x => x.Value)
                .IsRequired();

            builder.Property(x => x.MinAge)
                .IsRequired();

            builder.HasData(
                new AgeCategory {
                    Id = Guid.NewGuid(),
                    Value = "0+ - All ages are allowed",
                    MinAge = 0
                },
                new AgeCategory {
                    Id = Guid.NewGuid(),
                    Value = "6+ - For children over 6 years",
                    MinAge = 6
                },
                new AgeCategory {
                    Id = Guid.NewGuid(),
                    Value = "12+ - For children over 12 years",
                    MinAge = 12
                },
                new AgeCategory {
                    Id = Guid.NewGuid(),
                    Value = "16+ - For children over 16 years",
                    MinAge = 16
                },
                new AgeCategory {
                    Id = Guid.NewGuid(),
                    Value = "18+ - Prohibited for children",
                    MinAge = 18
                });
        }
    }
}
