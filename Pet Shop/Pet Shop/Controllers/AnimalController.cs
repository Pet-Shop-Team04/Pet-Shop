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
    public class AnimalController : ControllerBase
    {
        private readonly IAnimal _animal;

        public AnimalController(IAnimal animal)
        {
            _animal  = animal;
        }

        // POST: api/Animal
        [HttpPost]
        public async Task<ActionResult<Animal>> PostAnimal(AnimalDto animalDto)
        {
            Animal animals = await _animal.Create(animalDto);
            return Ok(animals);
        }

        // GET: api/Animal
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AnimalDto>>> GetAnimal()
        {
            var animals = await _animal.GetAnimals();
            return Ok(animals);
        }

        // GET: api/Animal/1
        [HttpGet("{id}")]
        public async Task<ActionResult<AnimalDto>> GetAnimal(int id)
        {
            AnimalDto amenitiesDto = await _animal.GetAnimal(id);
            return Ok(amenitiesDto);
        }

        // PUT: api/Animal/1
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnimal(int id, AnimalDto animalDto)
        {
            if (id != animalDto.AnimalId)
            {
                return BadRequest();
            }

            Animal animal1 = await _animal.UpdateAnimal(id, animalDto);
            return Ok(animal1);
        }

        // DELETE: api/Animal/21
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnimal(int id)
        {
            var animal = await _animal.GetAnimal(id);
            if (animal == null)
            {
                return NotFound();
            }

            await _animal.DeleteAnimal(id);
            return NoContent();
        }
    }
}
