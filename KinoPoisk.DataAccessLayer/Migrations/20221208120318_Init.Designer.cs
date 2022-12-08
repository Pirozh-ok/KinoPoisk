﻿// <auto-generated />
using System;
using KinoPoisk.DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace KinoPoisk.DataAccessLayer.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20221208120318_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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
                            Id = new Guid("80f5f8df-03b8-4820-b1ee-bb97b4a02b4a"),
                            MinAge = 0L,
                            Value = "0+ - All ages are allowed"
                        },
                        new
                        {
                            Id = new Guid("96ebcf82-1371-463a-8462-8eb9dff5b09f"),
                            MinAge = 6L,
                            Value = "6+ - For children over 6 years"
                        },
                        new
                        {
                            Id = new Guid("f7cd4e41-3cc8-4eb9-b323-3ae2b090e882"),
                            MinAge = 12L,
                            Value = "12+ - For children over 12 years"
                        },
                        new
                        {
                            Id = new Guid("e0ff79a5-4618-41d9-a173-2aa09d7c313a"),
                            MinAge = 16L,
                            Value = "16+ - For children over 16 years"
                        },
                        new
                        {
                            Id = new Guid("818b1891-a714-4e27-a433-327334bef0f8"),
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
                            Id = new Guid("692208a2-6c52-41fa-9db7-24ee68cec1b4"),
                            ConcurrencyStamp = "80c1593b-9abd-49a1-b5cf-81e330fc136c",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = new Guid("64b46c5a-0923-4942-bde5-59d2d05538fa"),
                            ConcurrencyStamp = "fbd41a4c-b447-4470-b6f7-492087aa6fd8",
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
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            Id = new Guid("8dd8d11e-261e-439e-8007-3b815257f3cd"),
                            Name = "Russia"
                        },
                        new
                        {
                            Id = new Guid("8285b35d-9290-472d-962a-c5c738a00849"),
                            Name = "USA"
                        },
                        new
                        {
                            Id = new Guid("23075e0f-1d6d-4774-aa3f-ca5ef54f9ea5"),
                            Name = "England"
                        },
                        new
                        {
                            Id = new Guid("69409d70-bc32-484b-b99b-74a50091c8df"),
                            Name = "France"
                        },
                        new
                        {
                            Id = new Guid("307810ea-f450-40d1-a97b-ea19f68ca871"),
                            Name = "Germany"
                        },
                        new
                        {
                            Id = new Guid("e4d95efc-4434-4471-a0eb-d3ccbf181e1a"),
                            Name = "China"
                        },
                        new
                        {
                            Id = new Guid("714cebff-1a3c-4d19-b92e-a6a34301bc77"),
                            Name = "Japan"
                        },
                        new
                        {
                            Id = new Guid("2731d6a4-7324-40d4-8cb0-6f16014f6cbe"),
                            Name = "Canada"
                        },
                        new
                        {
                            Id = new Guid("f48264a7-769c-4c9c-90ab-93fd36c30b67"),
                            Name = "Finlyadnia"
                        },
                        new
                        {
                            Id = new Guid("4f1cab76-1277-4236-84d2-74cfcb7eea07"),
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
                            Id = new Guid("0405452a-3dba-4984-ac07-de012aafa696"),
                            Name = "Horror movie"
                        },
                        new
                        {
                            Id = new Guid("f45aefc0-cbbc-443f-9ef5-f107e28b8e28"),
                            Name = "Action movie"
                        },
                        new
                        {
                            Id = new Guid("b623d720-396a-4610-8766-e124f59e4f9a"),
                            Name = "Fantasy"
                        },
                        new
                        {
                            Id = new Guid("8ae29546-1098-4f94-9537-19cf4219d768"),
                            Name = "Thriller"
                        },
                        new
                        {
                            Id = new Guid("f07879ec-b07f-4931-a4d2-646462d8c0c3"),
                            Name = "Detective"
                        },
                        new
                        {
                            Id = new Guid("f10466d6-20fd-4a36-8a77-09850d35ba38"),
                            Name = "Drama"
                        },
                        new
                        {
                            Id = new Guid("d4b943e8-22bc-4c4e-8bcc-ecff39e5a71b"),
                            Name = "Kids"
                        },
                        new
                        {
                            Id = new Guid("6fefb7f4-ebd2-40f9-a8b3-993c75c7d4c2"),
                            Name = "Comedy"
                        },
                        new
                        {
                            Id = new Guid("296c41d7-b1c3-47be-b9ac-442da2a728d2"),
                            Name = "Adventures"
                        },
                        new
                        {
                            Id = new Guid("8afa1a48-e53f-484d-add8-1c1347d3eb0f"),
                            Name = "War Film"
                        },
                        new
                        {
                            Id = new Guid("1fa3cc8a-b94e-49f7-8168-bef6ccb9da87"),
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
                            Id = new Guid("6cefb5bb-9f53-4b79-a8a8-0459be12e1d2"),
                            Name = "Director"
                        },
                        new
                        {
                            Id = new Guid("7ff95043-8af8-48c3-b9f1-7035662c1b2e"),
                            Name = "Actors"
                        },
                        new
                        {
                            Id = new Guid("a4340769-f79f-48e5-aea0-09164a113a13"),
                            Name = "Composer"
                        },
                        new
                        {
                            Id = new Guid("dcd5644c-f38b-4326-bdeb-a9b42589e5fe"),
                            Name = "ScreenWriters"
                        },
                        new
                        {
                            Id = new Guid("8b0aa46d-bde2-4fcd-9141-d5771b6c25bb"),
                            Name = "Producers"
                        },
                        new
                        {
                            Id = new Guid("157cf1a4-b8bd-46f2-ae61-fd84510ea3e5"),
                            Name = "Artists"
                        },
                        new
                        {
                            Id = new Guid("12875772-dbe6-4c28-b267-59e1fed704fb"),
                            Name = "Operators"
                        },
                        new
                        {
                            Id = new Guid("2613f867-6c1c-4e5a-8a56-04e9e11e2c38"),
                            Name = "Director"
                        });
                });

            modelBuilder.Entity("KinoPoisk.DomainLayer.Entities.Rating", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MovieId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasDefaultValue("");

                    b.Property<long>("MovieRating")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasDefaultValue(0L);

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
                        .HasForeignKey("CountryId");

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
                        .WithMany("Content")
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
                        .WithMany("Creators_Movies")
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

                    b.Navigation("Content");

                    b.Navigation("Creators_Movies");

                    b.Navigation("Ratings");
                });
#pragma warning restore 612, 618
        }
    }
}