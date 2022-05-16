using Microsoft.EntityFrameworkCore;
using Pet_Shop.Data;
using Pet_Shop.Models.DTO;
using Pet_Shop.Models.DTOs;
using Pet_Shop.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pet_Shop.Models.Services
{
    public class AnimalServices : IAnimal
    {
        private readonly PetDbContext _context;

        public AnimalServices(PetDbContext context)
        {
            _context = context;
        }

        public async Task<Animal> Create(AnimalDto animalDto)
        {
            if (animalDto.DateOfBerth > DateTime.Now)
                throw new Exception("Birthdate can not be in future!");

            Animal animal = new Animal
            {
                Name = animalDto.Name,
                Gender = animalDto.Gender,
                Price = animalDto.Price,
                DateOfBerth = animalDto.DateOfBerth,
                Type = animalDto.AnimalType
            };

            _context.Entry(animal).State = EntityState.Added;

            await _context.SaveChangesAsync();
            return animal;
        }

        public async Task<AnimalDto> GetAnimal(int id)
        {
            return await _context.Animals.Select(
                animal => new AnimalDto
                {
                    AnimalId = animal.AnimalId,
                    Name = animal.Name,
                    Gender = animal.Gender,
                    Price = animal.Price,
                    DateOfBerth = animal.DateOfBerth,
                    Age = Calculate(animal.DateOfBerth),
                    AnimalType = animal.Type,
                    //Events = animal.AnimalEvents
                    //.Select(animalEvent => new AnimalEventDTO
                    //     {
                            
                    //        Event = animalEvent.Event
                            

                    //     }).ToList()
                }).FirstOrDefaultAsync(x => x.AnimalId == id);
        }

        public async Task<List<AnimalDto>> GetAnimals()
        {
            return await _context.Animals.Select(
                animal => new AnimalDto
                {
                    AnimalId = animal.AnimalId,
                    Name = animal.Name,
                    Gender = animal.Gender,
                    Price = animal.Price,
                    DateOfBerth = animal.DateOfBerth,
                    Age = Calculate(animal.DateOfBerth),
                    AnimalType= animal.Type
                }).ToListAsync();
        }

        public async Task<Animal> UpdateAnimal(int id, AnimalDto animalDto)
        {
            Animal animal = new Animal
            {
                Name = animalDto.Name,
                Gender = animalDto.Gender,
                Price = animalDto.Price,
                DateOfBerth = animalDto.DateOfBerth,
                Type = animalDto.AnimalType
            };

            _context.Entry(animal).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return animal;
        }

        public async Task DeleteAnimal(int id)
        {
            Animal animal = await _context.Animals.FindAsync(id);
            if (animal != null)
            {
                _context.Entry(animal).State = EntityState.Deleted;

                await _context.SaveChangesAsync();
            }
        }

        private static string Calculate(DateTime dateOfBirth)
        {
            DateTime today = DateTime.Now;

            // calculate the years
            int years = (int)(today.Subtract(dateOfBirth).TotalDays / 365.25);

            // add years to birthdate (born in 2000 doesn't mean you are 22)
            DateTime newBirthDate = dateOfBirth.AddYears(years);

            int months = 0;

            for (int i = 1; i <= 12; i++)
            {
                if (newBirthDate.AddMonths(i) == today)
                {
                    months = i;
                    break;
                }
                else if (newBirthDate.AddMonths(i) >= today)
                {
                    months = i - 1;
                    break;
                }
            }

            if (years == 0 && months == 0)
                return "New Born";
            else
                return years + " Years & " + months + " Months";
        }

        public async Task<AnimalEvent> AddEventToAnimal(int animalId, Event event1)
        {
            Event newEvent = new Event
            {
                Title = event1.Title,
                Date = event1.Date,
                Description = event1.Description,
                Status = event1.Status
            };

            _context.Entry(newEvent).State = EntityState.Added;
            await _context.SaveChangesAsync();

            AnimalEvent animalEvent = new AnimalEvent { AnimalId = animalId, EventId = newEvent.EventId };
            _context.Entry(animalEvent).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return animalEvent;
        }

        public async Task<AnimalEvent> AddEvent(AnimalEvent animalEvent)
        {
            _context.Entry(animalEvent).State = EntityState.Added;

            await _context.SaveChangesAsync();
            return animalEvent;
        }

        public async Task DeleteEvent(int animalId, int eventId)
        {
            AnimalEvent animalEvent = await _context.AnimalEvents.FirstOrDefaultAsync(x => x.AnimalId == animalId && x.EventId == eventId);
            if (animalEvent != null)
            {
                _context.Entry(animalEvent).State = EntityState.Deleted;

                await _context.SaveChangesAsync();
            }
        }

        public async Task<AnimalDto> GetAnimalbyname(string name)
        {
            return await _context.Animals.Select(
                   animal => new AnimalDto
                   {
                       AnimalId = animal.AnimalId,
                       Name = animal.Name,
                       Gender = animal.Gender,
                       Price = animal.Price,
                       DateOfBerth = animal.DateOfBerth,
                       AnimalType = animal.Type
                   }).FirstOrDefaultAsync(x => x.Name == name);
        }

        public async Task<List<AnimalDto>> GetAnimalsByType(string type)
        {
            return await _context.Animals.Select(
                 animal => new AnimalDto
                 {
                     AnimalId = animal.AnimalId,
                     Name = animal.Name,
                     Gender = animal.Gender,
                     Price = animal.Price,
                     DateOfBerth = animal.DateOfBerth,
                     AnimalType = animal.Type
                 }).Where(x => x.AnimalType == type).ToListAsync();
        }
    }
}
