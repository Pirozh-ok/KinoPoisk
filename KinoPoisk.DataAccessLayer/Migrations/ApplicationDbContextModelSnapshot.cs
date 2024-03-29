﻿// <auto-generated />
using System;
using KinoPoisk.DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace KinoPoisk.DataAccessLayer.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AgeCategoryMovie", b =>
                {
                    b.Property<Guid>("AgeCategoriesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MoviesId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("AgeCategoriesId", "MoviesId");

                    b.HasIndex("MoviesId");

                    b.ToTable("AgeCategoryMovie");
                });

            modelBuilder.Entity("CountryMovie", b =>
                {
                    b.Property<Guid>("CountriesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MoviesId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CountriesId", "MoviesId");

                    b.HasIndex("MoviesId");

                    b.ToTable("CountryMovie");
                });

            modelBuilder.Entity("CreatorMovieMovieRole", b =>
                {
                    b.Property<Guid>("RolesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CreatorMoviesCreatorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CreatorMoviesMovieId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("RolesId", "CreatorMoviesCreatorId", "CreatorMoviesMovieId");

                    b.HasIndex("CreatorMoviesCreatorId", "CreatorMoviesMovieId");

                    b.ToTable("CreatorMovieMovieRole");
                });

            modelBuilder.Entity("GenreMovie", b =>
                {
                    b.Property<Guid>("GenresId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MoviesId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("GenresId", "MoviesId");

                    b.HasIndex("MoviesId");

                    b.ToTable("GenreMovie");
                });

            modelBuilder.Entity("KinoPoisk.DomainLayer.Entities.AgeCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<long>("MinAge")
                        .HasColumnType("bigint");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AgeCategories");

                    b.HasData(
                        new
                        {
                            Id = new Guid("99bb58ef-08f7-4678-b94b-e7556a5ef5a3"),
                            MinAge = 0L,
                            Value = "0+ - All ages are allowed"
                        },
                        new
                        {
                            Id = new Guid("abfb38d3-92a1-4107-a330-3ad46bb5e2ef"),
                            MinAge = 6L,
                            Value = "6+ - For children over 6 years"
                        },
                        new
                        {
                            Id = new Guid("9c083b7f-1210-4d51-8b28-cdc47bc73677"),
                            MinAge = 12L,
                            Value = "12+ - For children over 12 years"
                        },
                        new
                        {
                            Id = new Guid("7a847696-7ac2-4f72-b310-b604136dc750"),
                            MinAge = 16L,
                            Value = "16+ - For children over 16 years"
                        },
                        new
                        {
                            Id = new Guid("e694c4df-fbca-40a8-ab23-a8b547f71add"),
                            MinAge = 18L,
                            Value = "18+ - Prohibited for children"
                        });
                });

            modelBuilder.Entity("KinoPoisk.DomainLayer.Entities.ApplicationRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("70b71bb5-8a25-4ba2-91a7-d431ad1cf6e6"),
                            ConcurrencyStamp = "c025e86d-595a-4a92-939e-e40ec73f78e5",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = new Guid("e84453a7-05fc-4049-a1c3-2af5da133b5a"),
                            ConcurrencyStamp = "07b6751d-1101-486c-9a7e-2a67f676f2d7",
                            Name = "User",
                            NormalizedName = "USER"
                        });
                });

            modelBuilder.Entity("KinoPoisk.DomainLayer.Entities.ApplicationUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("CountryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfRegistration")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Patronymic")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasDefaultValue("");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("RefreshTokenExpiryDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("KinoPoisk.DomainLayer.Entities.Award", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateOfAward")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("MovieId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("MovieId");

                    b.ToTable("Awards");
                });

            modelBuilder.Entity("KinoPoisk.DomainLayer.Entities.Content", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MovieId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MovieId");

                    b.ToTable("Contents");
                });

            modelBuilder.Entity("KinoPoisk.DomainLayer.Entities.Country", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            Id = new Guid("d3aa082f-9abe-45e1-a60d-84b93ab74c02"),
                            Name = "Russia"
                        },
                        new
                        {
                            Id = new Guid("59a77487-b1cc-46d4-b81d-e54d773045fd"),
                            Name = "USA"
                        },
                        new
                        {
                            Id = new Guid("7c4aaa3f-d92e-48fd-a1c3-443ff109f625"),
                            Name = "England"
                        },
                        new
                        {
                            Id = new Guid("c72e2ed3-da4f-4f2d-b1ab-b49b1b64a8fd"),
                            Name = "France"
                        },
                        new
                        {
                            Id = new Guid("9ddcaec0-7786-4ab2-b598-2e9995723d0f"),
                            Name = "Germany"
                        },
                        new
                        {
                            Id = new Guid("b0036039-705c-428e-b497-0323e1b88f58"),
                            Name = "China"
                        },
                        new
                        {
                            Id = new Guid("3cd368c3-35e5-4ea4-9886-6118c932399a"),
                            Name = "Japan"
                        },
                        new
                        {
                            Id = new Guid("709fb44b-7d7f-47f4-b9f0-ce55f5a2517c"),
                            Name = "Canada"
                        },
                        new
                        {
                            Id = new Guid("13483e4e-e66b-471c-9453-a51f4ea6a7f3"),
                            Name = "Finlyadnia"
                        },
                        new
                        {
                            Id = new Guid("a2ce5be0-cfde-4d89-8218-6da47275cde6"),
                            Name = "Sweden"
                        });
                });

            modelBuilder.Entity("KinoPoisk.DomainLayer.Entities.Creator", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Patronymic")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasDefaultValue("");

                    b.HasKey("Id");

                    b.ToTable("Creators");
                });

            modelBuilder.Entity("KinoPoisk.DomainLayer.Entities.CreatorMovie", b =>
                {
                    b.Property<Guid>("CreatorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MovieId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CreatorId", "MovieId");

                    b.HasIndex("MovieId");

                    b.ToTable("CreatorsMovies");
                });

            modelBuilder.Entity("KinoPoisk.DomainLayer.Entities.Genre", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            Id = new Guid("29cd2708-2c5b-41d9-815f-e27146127bcf"),
                            Name = "Horror movie"
                        },
                        new
                        {
                            Id = new Guid("c27d5478-0aaf-4885-840d-957c07b698f3"),
                            Name = "Action movie"
                        },
                        new
                        {
                            Id = new Guid("cab81dbd-c139-4b8d-957b-2a80843528e2"),
                            Name = "Fantasy"
                        },
                        new
                        {
                            Id = new Guid("5d6e07f2-a630-4e46-b073-536235376223"),
                            Name = "Thriller"
                        },
                        new
                        {
                            Id = new Guid("717415e2-b302-496e-9632-481bdbd41a7d"),
                            Name = "Detective"
                        },
                        new
                        {
                            Id = new Guid("0a6ee7c7-0281-42aa-b0b1-e631d14bdf4d"),
                            Name = "Drama"
                        },
                        new
                        {
                            Id = new Guid("bb980315-47e8-438e-af4e-a13a661991c5"),
                            Name = "Kids"
                        },
                        new
                        {
                            Id = new Guid("ef6233e8-698c-4ce0-bb65-c09f90fd27a9"),
                            Name = "Comedy"
                        },
                        new
                        {
                            Id = new Guid("3213189f-c30a-4065-a728-993c13baec11"),
                            Name = "Adventures"
                        },
                        new
                        {
                            Id = new Guid("56ab1800-eeae-4f6a-b9c8-b21f5d5edad9"),
                            Name = "War Film"
                        },
                        new
                        {
                            Id = new Guid("038b7a13-7c20-40fc-bf07-5008f11e0268"),
                            Name = "Musical"
                        });
                });

            modelBuilder.Entity("KinoPoisk.DomainLayer.Entities.Movie", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("BudgetInDollars")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasDefaultValue("");

                    b.Property<long>("DurationInMinutes")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("PremiereDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("WorldFeesInDollars")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("KinoPoisk.DomainLayer.Entities.MovieRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("MovieRoles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("0a5a7a92-f2ac-4899-9876-160aa40ebab0"),
                            Name = "Director"
                        },
                        new
                        {
                            Id = new Guid("e9f42ca0-8172-4648-bfda-27b3641af139"),
                            Name = "Actor"
                        },
                        new
                        {
                            Id = new Guid("b0fc6a91-8fa6-408f-8924-0609654a9fa6"),
                            Name = "Composer"
                        },
                        new
                        {
                            Id = new Guid("fa69e973-8618-41f6-b5c3-eaa925313295"),
                            Name = "ScreenWriter"
                        },
                        new
                        {
                            Id = new Guid("4fd31e4d-6ddf-42ae-b343-0622a560d513"),
                            Name = "Producer"
                        },
                        new
                        {
                            Id = new Guid("7f832a9e-848a-47f7-98cc-7b3b09f62f09"),
                            Name = "Artist"
                        },
                        new
                        {
                            Id = new Guid("61f8021a-26e8-4d5c-9036-6c92f2bc95fb"),
                            Name = "Operator"
                        },
                        new
                        {
                            Id = new Guid("376c4fc9-47d6-4db5-9cd6-7433f132a8f8"),
                            Name = "Editor"
                        });
                });

            modelBuilder.Entity("KinoPoisk.DomainLayer.Entities.Rating", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MovieId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Comment")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasDefaultValue("");

                    b.Property<long>("MovieRating")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasDefaultValue(0L);

                    b.Property<DateTime>("UpdateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.HasKey("UserId", "MovieId");

                    b.HasIndex("MovieId");

                    b.ToTable("Ratings");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUserRole<Guid>");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("KinoPoisk.DomainLayer.Entities.ApplicationUserRole", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>");

                    b.HasIndex("RoleId");

                    b.HasDiscriminator().HasValue("ApplicationUserRole");
                });

            modelBuilder.Entity("AgeCategoryMovie", b =>
                {
                    b.HasOne("KinoPoisk.DomainLayer.Entities.AgeCategory", null)
                        .WithMany()
                        .HasForeignKey("AgeCategoriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KinoPoisk.DomainLayer.Entities.Movie", null)
                        .WithMany()
                        .HasForeignKey("MoviesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CountryMovie", b =>
                {
                    b.HasOne("KinoPoisk.DomainLayer.Entities.Country", null)
                        .WithMany()
                        .HasForeignKey("CountriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KinoPoisk.DomainLayer.Entities.Movie", null)
                        .WithMany()
                        .HasForeignKey("MoviesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CreatorMovieMovieRole", b =>
                {
                    b.HasOne("KinoPoisk.DomainLayer.Entities.MovieRole", null)
                        .WithMany()
                        .HasForeignKey("RolesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KinoPoisk.DomainLayer.Entities.CreatorMovie", null)
                        .WithMany()
                        .HasForeignKey("CreatorMoviesCreatorId", "CreatorMoviesMovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GenreMovie", b =>
                {
                    b.HasOne("KinoPoisk.DomainLayer.Entities.Genre", null)
                        .WithMany()
                        .HasForeignKey("GenresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KinoPoisk.DomainLayer.Entities.Movie", null)
                        .WithMany()
                        .HasForeignKey("MoviesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("KinoPoisk.DomainLayer.Entities.ApplicationUser", b =>
                {
                    b.HasOne("KinoPoisk.DomainLayer.Entities.Country", "Country")
                        .WithMany("Users")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Country");
                });

            modelBuilder.Entity("KinoPoisk.DomainLayer.Entities.Award", b =>
                {
                    b.HasOne("KinoPoisk.DomainLayer.Entities.Movie", "Movie")
                        .WithMany("Awards")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("KinoPoisk.DomainLayer.Entities.Content", b =>
                {
                    b.HasOne("KinoPoisk.DomainLayer.Entities.Movie", "Movie")
                        .WithMany("Contents")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("KinoPoisk.DomainLayer.Entities.CreatorMovie", b =>
                {
                    b.HasOne("KinoPoisk.DomainLayer.Entities.Creator", "Creator")
                        .WithMany("CreatorsMovies")
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KinoPoisk.DomainLayer.Entities.Movie", "Movie")
                        .WithMany("CreatorsMovies")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Creator");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("KinoPoisk.DomainLayer.Entities.Rating", b =>
                {
                    b.HasOne("KinoPoisk.DomainLayer.Entities.Movie", "Movie")
                        .WithMany("Ratings")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KinoPoisk.DomainLayer.Entities.ApplicationUser", "User")
                        .WithMany("MovieRatings")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("KinoPoisk.DomainLayer.Entities.ApplicationRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("KinoPoisk.DomainLayer.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("KinoPoisk.DomainLayer.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("KinoPoisk.DomainLayer.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("KinoPoisk.DomainLayer.Entities.ApplicationUserRole", b =>
                {
                    b.HasOne("KinoPoisk.DomainLayer.Entities.ApplicationRole", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KinoPoisk.DomainLayer.Entities.ApplicationUser", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("KinoPoisk.DomainLayer.Entities.ApplicationRole", b =>
                {
                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("KinoPoisk.DomainLayer.Entities.ApplicationUser", b =>
                {
                    b.Navigation("MovieRatings");

                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("KinoPoisk.DomainLayer.Entities.Country", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("KinoPoisk.DomainLayer.Entities.Creator", b =>
                {
                    b.Navigation("CreatorsMovies");
                });

            modelBuilder.Entity("KinoPoisk.DomainLayer.Entities.Movie", b =>
                {
                    b.Navigation("Awards");

                    b.Navigation("Contents");

                    b.Navigation("CreatorsMovies");

                    b.Navigation("Ratings");
                });
#pragma warning restore 612, 618
        }
    }
}
