using Microsoft.EntityFrameworkCore;
using Pet_Shop.Data;
using Pet_Shop.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pet_Shop.Models.Services
{
    public class CartServices : ICart
    {
        private readonly PetDbContext _context;

        public CartServices(PetDbContext context)
        {
            _context = context;
        }
        public async Task<Cart> Create(Cart cart)
        {
            _context.Entry(cart).State = EntityState.Added;

            await _context.SaveChangesAsync();
            return cart;
        }

        public async Task DeleteCart(int UserId)
        {
            Cart cart = await GetCart(UserId);
            _context.Entry(cart).State = EntityState.Deleted;

            await _context.SaveChangesAsync();
        }

        public async Task<Cart> GetCart(int UserId)
        {

            Cart cart = await _context.Carts.FindAsync(UserId);
            return cart;
        }

        public async Task<List<Cart>> GetCarts()
        {
            var carts = await _context.Carts.ToListAsync();
            return carts;
        }

        public async Task<Cart> UpdateCart(Cart cart)
        {
            _context.Entry(cart).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return cart;
        }
    }
}
