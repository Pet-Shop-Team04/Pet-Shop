using Microsoft.EntityFrameworkCore;
using Pet_Shop.Data;
using Pet_Shop.Models.DTO;
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
        public async Task<AnimalProduct> Create(AnimalProductDto animalProductDto)
        {
            AnimalProduct animalProduct = new AnimalProduct
            {

                AnimalProdactId = animalProductDto.AnimalProdactId,
                ItemName = animalProductDto.ItemName,
                AnimalType = animalProductDto.AnimalType,
                ItemPrice = animalProductDto.ItemPrice,
                ItemDescription = animalProductDto.ItemDescription

            };



            _context.Entry(animalProduct).State = EntityState.Added;

            await _context.SaveChangesAsync();
            return animalProduct;
        }

        public async Task<AnimalProductDto> GetAnimalProduct(int Id)
        {

            return await _context.AnimalProducts.Select(

                     animalProduct => new AnimalProductDto
                     {

                         AnimalProdactId = animalProduct.AnimalProdactId,
                         ItemName= animalProduct.ItemName,
                         AnimalType= animalProduct.AnimalType,
                         ItemPrice= animalProduct.ItemPrice,
                         ItemDescription = animalProduct.ItemDescription,
                     
                      }

              ).FirstOrDefaultAsync(x => x.AnimalProdactId == Id);


        }

        public async Task<List<AnimalProductDto>> GetAnimalProducts()
        {
            return await _context.AnimalProducts.Select(

         animalProduct => new AnimalProductDto
         {

             AnimalProdactId = animalProduct.AnimalProdactId,
             ItemName = animalProduct.ItemName,
             AnimalType = animalProduct.AnimalType,
             ItemPrice = animalProduct.ItemPrice,
             ItemDescription = animalProduct.ItemDescription,
                         //ItemType = animalProduct.ItemType,
                         //Count = animalProduct.Count
                     }

              ).ToListAsync();

        }

        public async Task<AnimalProduct> UpdateAnimalProduct(int Id, AnimalProductDto animalProductDto)
        {

            AnimalProduct animalProduct = new AnimalProduct
            {

                AnimalProdactId = animalProductDto.AnimalProdactId,
                ItemName = animalProductDto.ItemName,
                AnimalType = animalProductDto.AnimalType,
                ItemPrice = animalProductDto.ItemPrice,
                ItemDescription = animalProductDto.ItemDescription

            };

            _context.Entry(animalProduct).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return animalProduct;

        }
        public async Task DeleteAnimalProduct(int id)
        {
            AnimalProduct animalProduct = await _context.AnimalProducts.FindAsync(id);
            if (animalProduct != null)
            {
                _context.Entry(animalProduct).State = EntityState.Deleted;

                await _context.SaveChangesAsync();
            }
        }

    }
}
