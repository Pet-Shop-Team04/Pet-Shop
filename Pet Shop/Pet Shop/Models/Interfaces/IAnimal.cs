using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pet_Shop.Models.Interfaces
{
    interface IAnimal
    {
        Task<Animal> Create(Animal animal);
        Task<Animal> GetAnimal(int Id);
        Task<List<Animal>> GetAnimals();
        Task<Animal> UpdateAnimal(int Id, Animal animal);
        Task DeleteAnimal(int Id);
    }
}
