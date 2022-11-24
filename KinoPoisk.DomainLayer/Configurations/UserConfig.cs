using KinoPoisk.DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KinoPoisk.DomainLayer.Configurations
{
    internal class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasIndex(x => x.Email)
                .IsUnique();

            builder.HasIndex(x => x.PhoneNumber)
                .IsUnique(); 

            builder.Property(x => x.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(x => x.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.LastName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.Patronymic)
                .HasDefaultValue(string.Empty)
                .HasMaxLength(50);

            builder.Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.DateOfBirth)
                .IsRequired();

            builder.Property(x => x.DateOfRegistration)
                .HasDefaultValueSql("getdate()");

            builder.Property(x => x.PhoneNumber)
                .IsRequired()
                .HasMaxLength(12);

            builder.Property(x => x.Password)
                .IsRequired()
                .HasMaxLength(30);

            builder
                .HasMany(x => x.MovieRatings)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.User.Id); 
        }
    }
}
