// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Pet_Shop.Data;

namespace Pet_Shop.Migrations
{
    [DbContext(typeof(PetDbContext))]
    partial class PetDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.16")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");

                    b.HasData(
                        new
                        {
                            Id = "ad376a8f",
                            ConcurrencyStamp = "561b2a00-47fe-4637-9abd-5f9adc766aa5",
                            Name = "Admin",
                            NormalizedName = "Admin"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");

                    b.HasData(
                        new
                        {
                            UserId = "a18be9c0",
                            RoleId = "ad376a8f"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Pet_Shop.Models.Animal", b =>
                {
                    b.Property<int>("AnimalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateOfBerth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AnimalId");

                    b.ToTable("Animals");

                    b.HasData(
                        new
                        {
                            AnimalId = 1,
                            DateOfBerth = new DateTime(2020, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Gender = "male",
                            Name = "alex",
                            Price = 30m,
                            Type = "cat"
                        },
                        new
                        {
                            AnimalId = 2,
                            DateOfBerth = new DateTime(2021, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Gender = "male",
                            Name = "sam",
                            Price = 230m,
                            Type = "dog"
                        },
                        new
                        {
                            AnimalId = 3,
                            DateOfBerth = new DateTime(2019, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Gender = "female",
                            Name = "sozan",
                            Price = 40m,
                            Type = "cat"
                        },
                        new
                        {
                            AnimalId = 4,
                            DateOfBerth = new DateTime(2022, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Gender = "female",
                            Name = "farah",
                            Price = 20m,
                            Type = "cat"
                        });
                });

            modelBuilder.Entity("Pet_Shop.Models.AnimalCart", b =>
                {
                    b.Property<int>("CartId")
                        .HasColumnType("int");

                    b.Property<int>("AnimalId")
                        .HasColumnType("int");

                    b.HasKey("CartId", "AnimalId");

                    b.HasIndex("AnimalId");

                    b.ToTable("AnimalCarts");

                    b.HasData(
                        new
                        {
                            CartId = 1,
                            AnimalId = 1
                        },
                        new
                        {
                            CartId = 1,
                            AnimalId = 2
                        },
                        new
                        {
                            CartId = 2,
                            AnimalId = 3
                        },
                        new
                        {
                            CartId = 2,
                            AnimalId = 4
                        });
                });

            modelBuilder.Entity("Pet_Shop.Models.AnimalEvent", b =>
                {
                    b.Property<int>("AnimalId")
                        .HasColumnType("int");

                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.HasKey("AnimalId", "EventId");

                    b.HasIndex("EventId");

                    b.ToTable("AnimalEvents");

                    b.HasData(
                        new
                        {
                            AnimalId = 1,
                            EventId = 1
                        },
                        new
                        {
                            AnimalId = 1,
                            EventId = 2
                        },
                        new
                        {
                            AnimalId = 2,
                            EventId = 3
                        },
                        new
                        {
                            AnimalId = 3,
                            EventId = 4
                        },
                        new
                        {
                            AnimalId = 3,
                            EventId = 5
                        },
                        new
                        {
                            AnimalId = 4,
                            EventId = 6
                        });
                });

            modelBuilder.Entity("Pet_Shop.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

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

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasData(
                        new
                        {
                            Id = "a18be9c0",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "b3969f1b-643c-40b3-b749-8aa8454833e1",
                            Email = "admin@gmail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "admin@gmail.com",
                            NormalizedUserName = "admin",
                            PasswordHash = "AQAAAAEAACcQAAAAENnaqR3IFVI7Q+RNRS8yVzlJMA9cb68uU0Us0ysKSGAOq2OuYvDsVjoxFanX4Emsow==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "",
                            TwoFactorEnabled = false,
                            UserName = "admin"
                        });
                });

            modelBuilder.Entity("Pet_Shop.Models.Cart", b =>
                {
                    b.Property<int>("CartId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("CartId");

                    b.HasIndex("UserId");

                    b.ToTable("Carts");

                    b.HasData(
                        new
                        {
                            CartId = 1,
                            Count = 0,
                            TotalPrice = 0m
                        },
                        new
                        {
                            CartId = 2,
                            Count = 0,
                            TotalPrice = 0m
                        },
                        new
                        {
                            CartId = 3,
                            Count = 0,
                            TotalPrice = 0m
                        });
                });

            modelBuilder.Entity("Pet_Shop.Models.CartProduct", b =>
                {
                    b.Property<int>("CartId")
                        .HasColumnType("int");

                    b.Property<int>("ProdactId")
                        .HasColumnType("int");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.HasKey("CartId", "ProdactId");

                    b.HasIndex("ProdactId");

                    b.ToTable("CartProducts");

                    b.HasData(
                        new
                        {
                            CartId = 1,
                            ProdactId = 1,
                            Amount = 3
                        },
                        new
                        {
                            CartId = 1,
                            ProdactId = 2,
                            Amount = 2
                        },
                        new
                        {
                            CartId = 2,
                            ProdactId = 3,
                            Amount = 4
                        },
                        new
                        {
                            CartId = 2,
                            ProdactId = 2,
                            Amount = 5
                        },
                        new
                        {
                            CartId = 3,
                            ProdactId = 1,
                            Amount = 1
                        });
                });

            modelBuilder.Entity("Pet_Shop.Models.Comment", b =>
                {
                    b.Property<int>("CommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AppUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CComment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("CommentId");

                    b.HasIndex("AppUserId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Pet_Shop.Models.CommentAnimal", b =>
                {
                    b.Property<int>("AnimalId")
                        .HasColumnType("int");

                    b.Property<int>("CommentId")
                        .HasColumnType("int");

                    b.HasKey("AnimalId", "CommentId");

                    b.HasIndex("CommentId");

                    b.ToTable("CommentAnimals");
                });

            modelBuilder.Entity("Pet_Shop.Models.Event", b =>
                {
                    b.Property<int>("EventId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EventId");

                    b.ToTable("Events");

                    b.HasData(
                        new
                        {
                            EventId = 1,
                            Date = new DateTime(2020, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "date for vaccine 1",
                            Status = true,
                            Title = "vaccine 1"
                        },
                        new
                        {
                            EventId = 2,
                            Date = new DateTime(2022, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "date for vaccine 2",
                            Status = false,
                            Title = "vaccine 2"
                        },
                        new
                        {
                            EventId = 3,
                            Date = new DateTime(2020, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "date for vaccine 1",
                            Status = true,
                            Title = "vaccine 1"
                        },
                        new
                        {
                            EventId = 4,
                            Date = new DateTime(2022, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "date for vaccine 1",
                            Status = false,
                            Title = "vaccine 1"
                        },
                        new
                        {
                            EventId = 5,
                            Date = new DateTime(2022, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "date for vaccine 2",
                            Status = false,
                            Title = "vaccine 2"
                        },
                        new
                        {
                            EventId = 6,
                            Date = new DateTime(2022, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "date for vaccine 1",
                            Status = false,
                            Title = "vaccine 1"
                        });
                });

            modelBuilder.Entity("Pet_Shop.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<string>("AnimalType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.HasKey("ProductId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            Amount = 12,
                            AnimalType = "cat",
                            Description = "10k of food for cats",
                            Name = "cat food 1",
                            Price = 20
                        },
                        new
                        {
                            ProductId = 2,
                            Amount = 12,
                            AnimalType = "dog",
                            Description = "10k of food for dogs",
                            Name = "dog food 1",
                            Price = 20
                        },
                        new
                        {
                            ProductId = 3,
                            Amount = 6,
                            AnimalType = "cat",
                            Description = "simple cat toy",
                            Name = "cat toy 1",
                            Price = 30
                        });
                });

            modelBuilder.Entity("Pet_Shop.Models.Rate", b =>
                {
                    b.Property<int>("RateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("RateValue")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("RateId");

                    b.ToTable("Rates");

                    b.HasData(
                        new
                        {
                            RateId = 1,
                            RateValue = 4,
                            UserId = 0
                        },
                        new
                        {
                            RateId = 2,
                            RateValue = 5,
                            UserId = 0
                        },
                        new
                        {
                            RateId = 3,
                            RateValue = 3,
                            UserId = 0
                        });
                });

            modelBuilder.Entity("Pet_Shop.Models.RateProduct", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("RateId")
                        .HasColumnType("int");

                    b.HasKey("ProductId", "RateId");

                    b.HasIndex("RateId");

                    b.ToTable("RateProducts");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            RateId = 1
                        },
                        new
                        {
                            ProductId = 2,
                            RateId = 2
                        },
                        new
                        {
                            ProductId = 1,
                            RateId = 3
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Pet_Shop.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Pet_Shop.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Pet_Shop.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Pet_Shop.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Pet_Shop.Models.AnimalCart", b =>
                {
                    b.HasOne("Pet_Shop.Models.Animal", "Animal")
                        .WithMany("AnimalCarts")
                        .HasForeignKey("AnimalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Pet_Shop.Models.Cart", "Cart")
                        .WithMany("AnimalCarts")
                        .HasForeignKey("CartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Animal");

                    b.Navigation("Cart");
                });

            modelBuilder.Entity("Pet_Shop.Models.AnimalEvent", b =>
                {
                    b.HasOne("Pet_Shop.Models.Animal", "Animal")
                        .WithMany("AnimalEvents")
                        .HasForeignKey("AnimalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Pet_Shop.Models.Event", "Event")
                        .WithMany("AnimalEvents")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Animal");

                    b.Navigation("Event");
                });

            modelBuilder.Entity("Pet_Shop.Models.Cart", b =>
                {
                    b.HasOne("Pet_Shop.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Pet_Shop.Models.CartProduct", b =>
                {
                    b.HasOne("Pet_Shop.Models.Cart", "Cart")
                        .WithMany("CartProducts")
                        .HasForeignKey("CartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Pet_Shop.Models.Product", "Prodact")
                        .WithMany("CartProducts")
                        .HasForeignKey("ProdactId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cart");

                    b.Navigation("Prodact");
                });

            modelBuilder.Entity("Pet_Shop.Models.Comment", b =>
                {
                    b.HasOne("Pet_Shop.Models.ApplicationUser", "AppUser")
                        .WithMany()
                        .HasForeignKey("AppUserId");

                    b.Navigation("AppUser");
                });

            modelBuilder.Entity("Pet_Shop.Models.CommentAnimal", b =>
                {
                    b.HasOne("Pet_Shop.Models.Animal", "Animal")
                        .WithMany("CommentAnimals")
                        .HasForeignKey("AnimalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Pet_Shop.Models.Comment", "Comment")
                        .WithMany("CommentAnimals")
                        .HasForeignKey("CommentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Animal");

                    b.Navigation("Comment");
                });

            modelBuilder.Entity("Pet_Shop.Models.RateProduct", b =>
                {
                    b.HasOne("Pet_Shop.Models.Product", "Product")
                        .WithMany("Ratings")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Pet_Shop.Models.Rate", "Rate")
                        .WithMany("Ratings")
                        .HasForeignKey("RateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Rate");
                });

            modelBuilder.Entity("Pet_Shop.Models.Animal", b =>
                {
                    b.Navigation("AnimalCarts");

                    b.Navigation("AnimalEvents");

                    b.Navigation("CommentAnimals");
                });

            modelBuilder.Entity("Pet_Shop.Models.Cart", b =>
                {
                    b.Navigation("AnimalCarts");

                    b.Navigation("CartProducts");
                });

            modelBuilder.Entity("Pet_Shop.Models.Comment", b =>
                {
                    b.Navigation("CommentAnimals");
                });

            modelBuilder.Entity("Pet_Shop.Models.Event", b =>
                {
                    b.Navigation("AnimalEvents");
                });

            modelBuilder.Entity("Pet_Shop.Models.Product", b =>
                {
                    b.Navigation("CartProducts");

                    b.Navigation("Ratings");
                });

            modelBuilder.Entity("Pet_Shop.Models.Rate", b =>
                {
                    b.Navigation("Ratings");
                });
#pragma warning restore 612, 618
        }
    }
}
