using Microsoft.EntityFrameworkCore;
using Pet_Shop.Data;
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

        public async Task<Animal> Create(Animal animal)
        {
            _context.Entry(animal).State = EntityState.Added;

            await _context.SaveChangesAsync();
            return animal;

        }

        public async Task<Animal> GetAnimal(int id)
        {
            Animal animal = await _context.Animals.FindAsync(id);
            return animal;
        }

        public async Task<List<Animal>> GetAnimals()
        {
            var animals = await _context.Animals.ToListAsync();
            return animals;
        }

        public async Task<Animal> UpdateAnimal(int id, Animal animal)
        {
            _context.Entry(animal).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return animal;


        }

        public async Task DeleteAnimal(int id)
        {
            Animal animal = await GetAnimal(id);
            _context.Entry(animal).State = EntityState.Deleted;

            await _context.SaveChangesAsync();
        }
    }
}
