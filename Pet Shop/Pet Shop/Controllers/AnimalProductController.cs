using System;
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
    public class AnimalProductController : ControllerBase
    {

        private readonly IAnimalProduct _animalProduct;
        public AnimalProductController(IAnimalProduct animalProduct)
        {
            _animalProduct  = animalProduct;
        }


        // POST: api/AnimalProduct
        [HttpPost]
        public async Task<ActionResult<AnimalProduct>> PostAnimalProduct(AnimalProductDto animalProductDto)
        {
            AnimalProduct animalDto = await _animalProduct.Create(animalProductDto);
            return Ok(animalDto);
        }
        // GET: api/AnimalProduct
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AnimalProductDto>>> GetAnimalProduct()
        {
            var animalProduct = await _animalProduct.GetAnimalProducts();
            return Ok(animalProduct);
        }

        // GET: api/AnimalProduct/1
        [HttpGet("{id}")]
        public async Task<ActionResult<AnimalProductDto>> GetAnimalProduct(int id)
        {

            AnimalProductDto animalProduct = await _animalProduct.GetAnimalProduct(id);

            return Ok(animalProduct);
        }

        // PUT: api/AnimalProduct/1
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnimalProduct(int id, AnimalProductDto animalProductDto)
        {

            AnimalProduct animal = await _animalProduct.UpdateAnimalProduct(id, animalProductDto);

            return Ok(animal);
        }


        // DELETE: api/AnimalProduct/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnimalProduct(int id)
        {

            var rooms = await _animalProduct.GetAnimalProduct(id);

            if (rooms == null)
            {
                return NotFound();
            }



            await _animalProduct.DeleteAnimalProduct(id);
            return NoContent();

        }

    }
}
