﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pet_Shop.Models;
using Pet_Shop.Models.DTO;
using Pet_Shop.Models.Interfaces;

namespace Pet_Shop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProduct _animalProduct;
        public ProductController(IProduct animalProduct)
        {
            _animalProduct  = animalProduct;
        }

        // POST: api/Product
        [HttpPost]
        public async Task<ActionResult<Product>> PostAnimalProduct(ProductDto animalProductDto)
        {
            Product animalDto = await _animalProduct.Create(animalProductDto);
            return Ok(animalDto);
        }

        // GET: api/Product
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetAnimalProduct()
        {
            var animalProduct = await _animalProduct.GetProducts();
            return Ok(animalProduct);
        }

        // GET: api/Product/1
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetAnimalProduct(int id)
        {
            ProductDto animalProduct = await _animalProduct.GetProduct(id);
            return Ok(animalProduct);
        }

        // PUT: api/Product/1
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnimalProduct(int id, ProductDto animalProductDto)
        {
            Product animal = await _animalProduct.UpdateProduct(id, animalProductDto);
            return Ok(animal);
        }

        // DELETE: api/Product/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnimalProduct(int id)
        {
            var product = await _animalProduct.GetProduct(id);

            if (product == null)
            {
                return NotFound();
            }

            await _animalProduct.DeleteProduct(id);
            return NoContent();
        }
    }
}