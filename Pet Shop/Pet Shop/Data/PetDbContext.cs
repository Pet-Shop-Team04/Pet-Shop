using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Pet_Shop.Models;
using System;

namespace Pet_Shop.Data
{
    public class PetDbContext : IdentityDbContext<ApplicationUser>
    {

        public DbSet<Animal> Animals { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<AnimalCart> AnimalCarts { get; set; }
        public DbSet<AnimalEvent> AnimalEvents { get; set; }
        public DbSet<CartProduct> CartProducts { get; set; }
        public DbSet<Rate> Rates { get; set; }
        public DbSet<RateProduct> RateProducts { get; set; }
        public DbSet<CommentAnimal> CommentAnimals { get; set; }
        public DbSet<Comment> Comments { get; set; }


        public PetDbContext(DbContextOptions options) : base(options)
        {
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);                      

            modelBuilder.Entity<AnimalCart>().HasKey(x => new { x.CartId, x.AnimalId });
            modelBuilder.Entity<AnimalEvent>().HasKey(x => new { x.AnimalId, x.EventId });
            modelBuilder.Entity<CartProduct>().HasKey(x => new { x.CartId, x.ProdactId });
            modelBuilder.Entity<RateProduct>().HasKey(x => new { x.ProductId, x.RateId });
            modelBuilder.Entity<CommentAnimal>().HasKey(x => new { x.AnimalId, x.CommentId });

            // any unique string id
            const string ADMIN_ID = "a18be9c0";
            const string ROLE_ID = "ad376a8f";

            // create an Admin role
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = ROLE_ID,
                Name = "Admin",
                NormalizedName = "Admin"
            });

            // create a User
            var hasher = new PasswordHasher<ApplicationUser>();
            modelBuilder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = ADMIN_ID,
                UserName = "admin",
                NormalizedUserName = "admin",
                Email = "admin@gmail.com",
                NormalizedEmail = "admin@gmail.com",
                EmailConfirmed = false,
                PasswordHash = hasher.HashPassword(null, "Admin123#"),
                SecurityStamp = string.Empty
            });

            // assign that user to the admin role
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = ROLE_ID,
                UserId = ADMIN_ID
            });

            modelBuilder.Entity<Animal>().HasData(
                
                new Animal {AnimalId = 1, Name = "alex" ,Gender= "male",Price = 30, DateOfBerth =new DateTime(2020,5,3) , Type= "cat"  },


                new Animal { AnimalId = 2, Name = "sam", Gender = "male", Price = 230, DateOfBerth = new DateTime(2021, 3, 5), Type = "dog" },


                new Animal { AnimalId = 3, Name = "sozan", Gender = "female", Price = 40, DateOfBerth = new DateTime(2019, 2, 3), Type = "cat" },


                new Animal { AnimalId = 4, Name = "farah", Gender = "female", Price = 20, DateOfBerth = new DateTime(2022, 1, 3), Type = "cat" }

                );


            modelBuilder.Entity<Product>().HasData(
         new Product { ProductId = 1 , Name = "cat food 1" , AnimalType = "cat", Description ="10k of food for cats", Price = 20, Amount = 12  },
          new Product { ProductId = 2, Name = "dog food 1", AnimalType = "dog", Description = "10k of food for dogs", Price = 20, Amount = 12 },
           new Product { ProductId = 3, Name = "cat toy 1", AnimalType = "cat", Description = "simple cat toy", Price = 30, Amount = 6 }

          );

            modelBuilder.Entity<Event>().HasData(
          new Event { EventId =1 ,Title= "vaccine 1", Date  = new DateTime(2020, 2, 3), Description = "date for vaccine 1" , Status = true },
          new Event { EventId = 2, Title = "vaccine 2", Date = new DateTime(2022, 5, 2), Description = "date for vaccine 2", Status = false },
          new Event { EventId = 3, Title = "vaccine 1", Date = new DateTime(2020, 6, 2), Description = "date for vaccine 1", Status = true },
          new Event { EventId = 4, Title = "vaccine 1", Date = new DateTime(2022, 4, 8), Description = "date for vaccine 1", Status = false },
          new Event { EventId = 5, Title = "vaccine 2", Date = new DateTime(2022, 7, 2), Description = "date for vaccine 2", Status = false },
          new Event { EventId = 6, Title = "vaccine 1", Date = new DateTime(2022,8, 8), Description = "date for vaccine 1", Status = false }
           );


            modelBuilder.Entity<Cart>().HasData(
                new Cart { CartId = 1 },
                new Cart { CartId = 2 },
                new Cart { CartId = 3 }
                 );

            modelBuilder.Entity<CartProduct>().HasData(
            new CartProduct { CartId = 1 , ProdactId = 1, Amount = 3},
            new CartProduct { CartId = 1, ProdactId = 2, Amount = 2},
            new CartProduct { CartId = 2, ProdactId = 3 , Amount = 4},
            new CartProduct { CartId = 2, ProdactId = 2 , Amount = 5},
            new CartProduct { CartId = 3, ProdactId = 1, Amount = 1 }
             );

            modelBuilder.Entity<AnimalCart>().HasData(
           new AnimalCart { CartId = 1, AnimalId = 1 },
           new AnimalCart { CartId = 1, AnimalId = 2 },
           new AnimalCart { CartId = 2, AnimalId = 3 },
           new AnimalCart { CartId = 2, AnimalId = 4 }
            );


            modelBuilder.Entity<AnimalEvent>().HasData(
               new AnimalEvent {AnimalId = 1 , EventId = 1 },
               new AnimalEvent { AnimalId = 1, EventId = 2 },
               new AnimalEvent { AnimalId = 2, EventId = 3 },
               new AnimalEvent { AnimalId = 3, EventId = 4 },
               new AnimalEvent { AnimalId = 3, EventId = 5 },
               new AnimalEvent { AnimalId = 4, EventId = 6 }
                );




         
            modelBuilder.Entity<Rate>().HasData(
                new Rate { RateId = 1 , RateValue =  4},
                new Rate { RateId = 2, RateValue = 5 },
                new Rate { RateId = 3, RateValue = 3 }


                );

             modelBuilder.Entity<RateProduct>().HasData(
               new RateProduct { ProductId = 1, RateId = 1},
               new RateProduct { ProductId = 2, RateId = 2 },
               new RateProduct { ProductId = 1, RateId = 3 }
               );




        }
}
}
