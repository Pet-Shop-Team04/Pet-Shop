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
    public class AnimalServices : IAnimal
    {
        private readonly PetDbContext _context;

        public AnimalServices(PetDbContext context)
        {
            _context = context;
        }

        public async Task<Animal> Create(AnimalDto animalDto)
        {

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
                    AnimalType = animal.Type
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
    }
}
