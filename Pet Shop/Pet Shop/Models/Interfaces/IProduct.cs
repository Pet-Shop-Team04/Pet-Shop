using Pet_Shop.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pet_Shop.Models.Interfaces
{
   public interface IProduct
    {
        Task<Product> Create(ProductDto animalProduct);
        Task<ProductDto> GetProduct(int Id);
        Task<List<ProductDto>> GetProducts();
        Task<Product> UpdateProduct(int Id, ProductDto animalProdusct);
        Task DeleteProduct(int Id);

        Task<ProductDto> GetProductbyname(string name);

        Task<List<ProductDto>> GetProductsByType(string type);

        Task<RateProduct> AddRateToProduct(int productId, int rateValue);
    }
}
