﻿using KinoPoisk.DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KinoPoisk.DataAccessLayer.Configurations {
    internal class UserConfig : IEntityTypeConfiguration<ApplicationUser> {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder) {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(x => x.FirstName)
                .IsRequired()
                .HasMaxLength(Constants.MaxLenOfName);

            builder.Property(x => x.LastName)
                .IsRequired()
                .HasMaxLength(Constants.MaxLenOfName);

            builder.Property(x => x.Patronymic)
                .HasDefaultValue(string.Empty)
                .HasMaxLength(Constants.MaxLenOfName);

            builder.Property(x => x.DateOfBirth)
                .IsRequired();

            builder.Property(x => x.DateOfRegistration)
                .HasDefaultValueSql("getdate()");

            builder
                .HasMany(x => x.MovieRatings)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId);

            builder
                .HasMany(x => x.UserRoles)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId);

            builder
                .HasOne(x => x.Country)
                .WithMany(x => x.Users)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
