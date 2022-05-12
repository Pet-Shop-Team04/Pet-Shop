using Pet_Shop.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pet_Shop.Models.Interfaces
{
  public interface IAnimal
    {
        Task<Animal> Create(AnimalDto animal);
        Task<AnimalDto> GetAnimal(int Id);
        Task<List<AnimalDto>> GetAnimals();
        Task<Animal> UpdateAnimal(int Id, AnimalDto animal);
        Task DeleteAnimal(int Id);
    }
}
