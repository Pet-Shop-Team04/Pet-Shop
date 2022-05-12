using Microsoft.EntityFrameworkCore;
using Pet_Shop.Data;
using Pet_Shop.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pet_Shop.Models.Services
{
    public class AnimalProductServices : IAnimalProduct
    {
        private readonly PetDbContext _context;

        public AnimalProductServices(PetDbContext context)
        {
            _context = context;
        }
        public async Task<AnimalProduct> Create(AnimalProduct animalProduct)
        {
            _context.Entry(animalProduct).State = EntityState.Added;

            await _context.SaveChangesAsync();
            return animalProduct;
        }

        public async Task DeleteAnimalProduct(int Id)
        {
            AnimalProduct animalProdact = await GetAnimalProduct(Id);
            _context.Entry(animalProdact).State = EntityState.Deleted;

            await _context.SaveChangesAsync();
        }
        public async Task<AnimalProduct> GetAnimalProduct(int Id)
        {

            AnimalProduct animalProduct = await _context.AnimalProducts.FindAsync(Id);
            return animalProduct;
        }

        public async Task<List<AnimalProduct>> GetAnimalProducts()
        {
            var animalProducts = await _context.AnimalProducts.ToListAsync();
            return animalProducts;
        }

        public async Task<AnimalProduct> UpdateAnimalProduct(int Id, AnimalProduct animalProduct)
        {
            _context.Entry(animalProduct).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return animalProduct;

        }
    }
}
