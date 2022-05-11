﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Pet_Shop.Data;

namespace Pet_Shop.Migrations
{
    [DbContext(typeof(PetDbContext))]
    [Migration("20220511150441_AddAllTable1")]
    partial class AddAllTable1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.16")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Pet_Shop.Models.Animal", b =>
                {
                    b.Property<int>("AnimalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AnimalType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfBerth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("AnimalId");

                    b.ToTable("Animals");
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
                });

            modelBuilder.Entity("Pet_Shop.Models.AnimalProdact", b =>
                {
                    b.Property<int>("AnimalProdactId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AnimalType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<string>("ItemDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ItemName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ItemPrice")
                        .HasColumnType("int");

                    b.Property<string>("ItemType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AnimalProdactId");

                    b.ToTable("AnimalProdacts");
                });

            modelBuilder.Entity("Pet_Shop.Models.Cart", b =>
                {
                    b.Property<int>("CartId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<int>("TotalPrice")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("CartId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("Pet_Shop.Models.CartAnimalProduct", b =>
                {
                    b.Property<int>("CartId")
                        .HasColumnType("int");

                    b.Property<int>("AnimalProdactId")
                        .HasColumnType("int");

                    b.HasKey("CartId", "AnimalProdactId");

                    b.HasIndex("AnimalProdactId");

                    b.ToTable("CartAnimalProducts");
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

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("statuse")
                        .HasColumnType("bit");

                    b.HasKey("EventId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("Pet_Shop.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Pet_Shop.Models.AnimalCart", b =>
                {
                    b.HasOne("Pet_Shop.Models.Animal", "Animals")
                        .WithMany("AnimalCarts")
                        .HasForeignKey("AnimalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Pet_Shop.Models.Cart", "Carts")
                        .WithMany("AnimalCarts")
                        .HasForeignKey("CartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Animals");

                    b.Navigation("Carts");
                });

            modelBuilder.Entity("Pet_Shop.Models.AnimalEvent", b =>
                {
                    b.HasOne("Pet_Shop.Models.Animal", "Animals")
                        .WithMany("AnimalEvents")
                        .HasForeignKey("AnimalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Pet_Shop.Models.Event", "Events")
                        .WithMany("AnimalEvents")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Animals");

                    b.Navigation("Events");
                });

            modelBuilder.Entity("Pet_Shop.Models.Cart", b =>
                {
                    b.HasOne("Pet_Shop.Models.User", "Users")
                        .WithOne("Carts")
                        .HasForeignKey("Pet_Shop.Models.Cart", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Users");
                });

            modelBuilder.Entity("Pet_Shop.Models.CartAnimalProduct", b =>
                {
                    b.HasOne("Pet_Shop.Models.AnimalProdact", "AnimalProdacts")
                        .WithMany()
                        .HasForeignKey("AnimalProdactId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Pet_Shop.Models.Cart", "Carts")
                        .WithMany("CartAnimalProducts")
                        .HasForeignKey("CartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AnimalProdacts");

                    b.Navigation("Carts");
                });

            modelBuilder.Entity("Pet_Shop.Models.Animal", b =>
                {
                    b.Navigation("AnimalCarts");

                    b.Navigation("AnimalEvents");
                });

            modelBuilder.Entity("Pet_Shop.Models.Cart", b =>
                {
                    b.Navigation("AnimalCarts");

                    b.Navigation("CartAnimalProducts");
                });

            modelBuilder.Entity("Pet_Shop.Models.Event", b =>
                {
                    b.Navigation("AnimalEvents");
                });

            modelBuilder.Entity("Pet_Shop.Models.User", b =>
                {
                    b.Navigation("Carts");
                });
#pragma warning restore 612, 618
        }
    }
}
