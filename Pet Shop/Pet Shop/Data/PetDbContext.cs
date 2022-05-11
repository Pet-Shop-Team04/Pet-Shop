using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Pet_Shop.Models;

namespace Pet_Shop.Data
{
    public class PetDbContext : IdentityDbContext<ApplicationUser>
    {

        public DbSet<Animal> Animals { get; set; }
        public DbSet<AnimalProdact> AnimalProdacts { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Event> Events { get; set; }

        public DbSet<AnimalCart> AnimalCarts { get; set; }

        public DbSet<AnimalEvent> AnimalEvents { get; set; }

        public DbSet<CartAnimalProduct> CartAnimalProducts { get; set; }
            
        public PetDbContext(DbContextOptions options) : base(options)
        {
           
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);                      

            modelBuilder.Entity<AnimalCart>().HasKey(x => new { x.CartId, x.AnimalId });
            modelBuilder.Entity<AnimalEvent>().HasKey(x => new { x.AnimalId, x.EventId });
            modelBuilder.Entity<CartAnimalProduct>().HasKey(x => new { x.CartId, x.AnimalProdactId });




        }
    }
}
