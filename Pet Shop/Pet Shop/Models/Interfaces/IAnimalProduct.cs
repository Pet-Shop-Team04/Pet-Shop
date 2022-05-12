using Pet_Shop.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pet_Shop.Models.Interfaces
{
   public interface IAnimalProduct
    {
        Task<AnimalProduct> Create(AnimalProductDto animalProduct);
        Task<AnimalProductDto> GetAnimalProduct(int Id);
        Task<List<AnimalProductDto>> GetAnimalProducts();
        Task<AnimalProduct> UpdateAnimalProduct(int Id, AnimalProductDto animalProdusct);
        Task DeleteAnimalProduct(int Id);
    }
}
