using KinoPoisk.DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KinoPoisk.DomainLayer.Configurations
{
    internal class AgeCategoryConfig : IEntityTypeConfiguration<AgeCategory>
    {
        public void Configure(EntityTypeBuilder<AgeCategory> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .IsRequired(); 

            builder.Property(x => x.Value)
                .IsRequired(); 
        }
    }
}
