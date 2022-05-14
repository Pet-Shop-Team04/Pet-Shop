﻿using Microsoft.EntityFrameworkCore;
using Pet_Shop.Data;
using Pet_Shop.Models.DTO;
using Pet_Shop.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pet_Shop.Models.Services
{
    public class ProductServices : IProduct
    {
        private readonly PetDbContext _context;

        public ProductServices(PetDbContext context)
        {
            _context = context;
        }
        public async Task<Product> Create(ProductDto animalProductDto)
        {
            Product animalProduct = new Product
            {
                Id = animalProductDto.ProdactId,
                Name = animalProductDto.Name,
                AnimalType = animalProductDto.AnimalType,
                Price = animalProductDto.Price,
                Description = animalProductDto.Description
            };

            _context.Entry(animalProduct).State = EntityState.Added;

            await _context.SaveChangesAsync();
            return animalProduct;
        }

        public async Task<ProductDto> GetProduct(int Id)
        {

            return await _context.Products.Select(

                     animalProduct => new ProductDto
                     {
                         ProdactId = animalProduct.Id,
                         Name= animalProduct.Name,
                         AnimalType= animalProduct.AnimalType,
                         Price= animalProduct.Price,
                         Description = animalProduct.Description,
                     }

              ).FirstOrDefaultAsync(x => x.ProdactId == Id);
        }

        public async Task<List<ProductDto>> GetProducts()
        {
            return await _context.Products.Select(

        animalProduct => new ProductDto
        {
             ProdactId = animalProduct.Id,
             Name = animalProduct.Name,
             AnimalType = animalProduct.AnimalType,
             Price = animalProduct.Price,
             Description = animalProduct.Description,
             //ItemType = animalProduct.ItemType,
             //Count = animalProduct.Count
             }).ToListAsync();
        }

        public async Task<Product> UpdateProduct(int Id, ProductDto animalProductDto)
        {

            Product animalProduct = new Product
            {
                Id = animalProductDto.ProdactId,
                Name = animalProductDto.Name,
                AnimalType = animalProductDto.AnimalType,
                Price = animalProductDto.Price,
                Description = animalProductDto.Description
            };

            _context.Entry(animalProduct).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return animalProduct;

        }
        public async Task DeleteProduct(int id)
        {
            Product animalProduct = await _context.Products.FindAsync(id);
            if (animalProduct != null)
            {
                _context.Entry(animalProduct).State = EntityState.Deleted;

                await _context.SaveChangesAsync();
            }
        }

    }
}
