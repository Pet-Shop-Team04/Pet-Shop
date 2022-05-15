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
            _animal = animal;
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
            AnimalDto animalDto = await _animal.GetAnimal(id);
            return Ok(animalDto);
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
        // POST: api/Animal/3/addEvent
        [HttpPost("{id}/addEvent")]
        public async Task<ActionResult<AnimalEvent>> AddEvent(int id, Event event1)
        {
            AnimalEvent animalEvent = await _animal.AddEventToAnimal(id, event1);
            return Ok(animalEvent);
        }



        //[HttpPost("Animal/{id}/addEvent")]
        //public async Task<ActionResult<Animal>> PostAnimal(AnimalDto animalDto)
        //{
        //    Animal animals = await _animal.Create(animalDto);
        //    return Ok(animals);
        //}



        // DELETE: api/Animal/1/Event/1
        [HttpDelete("{animalId}/Event/{eventId}")]
        public async Task<IActionResult> DeleteEvent(int animalId, int eventId)
        {
            //var animal = await _animal.GetAnimal(id);
            //if (animal == null)
            //{
            //    return NotFound();
            //}

            await _animal.DeleteEvent(animalId, eventId);
            return NoContent();
        }
        // GET: api/Animal/Name/animalname
        [HttpGet("Name/{name}")]
        public async Task<ActionResult<IEnumerable<AnimalDto>>> GetAnimalByName(string name)
        {
            AnimalDto animal = await _animal.GetAnimalbyname(name);
            if (animal == null) 
            {
                return BadRequest($"no animal with {name} name");
            }


            return Ok(animal);
        }

        // GET: api/Animal/Type/cat
        [HttpGet("Type/{type}")]
        public async Task<ActionResult<AnimalDto>> GetAnimalsByType(string type)
        {
            var animals = await _animal.GetAnimalsByType(type);
            return Ok(animals);
        }
    }
}
