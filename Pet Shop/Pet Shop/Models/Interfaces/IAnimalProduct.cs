using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pet_Shop.Models.Interfaces
{
   public interface IAnimalProduct
    {
        Task<AnimalProduct> Create(AnimalProduct animalProduct);
        Task<AnimalProduct> GetAnimalProduct(int Id);
        Task<List<AnimalProduct>> GetAnimalProducts();
        Task<AnimalProduct> UpdateAnimalProduct(int Id, AnimalProduct animalProdusct);
        Task DeleteAnimalProduct(int Id);
    }
}
