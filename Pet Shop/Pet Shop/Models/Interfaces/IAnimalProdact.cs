using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pet_Shop.Models.Interfaces
{
    interface IAnimalProdact
    {
        Task<AnimalProdact> Create(AnimalProdact animalProdact);
        Task<AnimalProdact> GetAnimalProdact(int Id);
        Task<List<AnimalProdact>> GetAnimalProdacts();
        Task<AnimalProdact> UpdateAnimalProdact(int Id, AnimalProdact animalProdact);
        Task DeleteAnimalProdact(int Id);
    }
}
