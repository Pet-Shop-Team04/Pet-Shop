using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pet_Shop.Models.Interfaces
{
    interface ICart
    {
        Task<Cart> Create(Cart cart);
        Task<Cart> GetCart(int UserId);
        Task<List<Cart>> GetCarts();
        Task<Cart> UpdateCart(Cart cart);
        Task DeleteCart(int UserId);
    }
}
