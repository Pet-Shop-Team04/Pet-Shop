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

        Task<AnimalDto> GetAnimalbyname(string name);
    
       // Task<AnimalDto> GetAnimalbyType(string type);
        Task<List<AnimalDto>> GetAnimalsByType(string type);

        Task<AnimalEvent> AddEventToAnimal(int animalId, Event Event);
        Task<AnimalEvent> AddEvent(AnimalEvent animalEvent);
        Task DeleteEvent(int animalId, int eventId);
        Task<CommentAnimal> AddCommentToAnimal(int AniamlID, string Comment);

        Task DeleteComment(int animalId, int commenttId);
    }
}
