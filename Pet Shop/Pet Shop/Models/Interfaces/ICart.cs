using Microsoft.AspNetCore.Mvc.ModelBinding;
using Pet_Shop.Models.DTO;
using Pet_Shop.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pet_Shop.Models.Interfaces
{
   public interface ICart
    {
        Task<Cart> Create();
        Task<CartDTO> GetCart(int UserId);
        Task<List<CartDTO2>> GetCarts();
        Task<Cart> UpdateCart(int Id, CartDTO cartDto);
        Task DeleteCart(int UserId);


       


        Task<AnimalCart> AddAnimalToCart( int cartId,int animalId);

        Task DeleteAnimalFromCart(int cartId, int animalId);

        Task<CartProduct> AddproductToCart(int cartId, int productId);

        Task DeleteproductFromCart(int cartId, int productId);





        Task<bool> checkItems(int cartId, ModelStateDictionary modelState);
        Task emptyTheCart(int cartId);
        Task<CartDTO> fixTheCart(int cartId, ModelStateDictionary modelState);
        Task<decimal> getTotalAmount(int cartId);

        Task buy(int cartId, ModelStateDictionary modelState);
        
    }
}
