using Pet_Shop.Models.DTO;
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
        Task<List<CartDTO>> GetCarts();
        Task<Cart> UpdateCart(int Id, CartDTO cartDto);
        Task DeleteCart(int UserId);
    }
}
