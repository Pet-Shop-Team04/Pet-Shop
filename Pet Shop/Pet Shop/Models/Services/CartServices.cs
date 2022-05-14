using Microsoft.EntityFrameworkCore;
using Pet_Shop.Data;
using Pet_Shop.Models.DTO;
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


        public async Task<Cart> Create()
        {

            Cart cart = new Cart
            {

                TotalPrice = 0,
                Count = 0
            };




            _context.Entry(cart).State = EntityState.Added;

            await _context.SaveChangesAsync();
            return cart;
        }

       

       

        public async Task<CartDTO> GetCart(int UserId)
        {
            return await _context.Carts.Select(

                     cart => new CartDTO
                     {

                         CartId = cart.CartId,
                     
                         TotalPrice = cart.TotalPrice,

                         Count = cart.Count,



                     }

              ).FirstOrDefaultAsync(x => x.CartId == UserId); 

        }

        public async Task<List<CartDTO>> GetCarts()
        {
            return await _context.Carts.Select(

                      cart => new CartDTO
                      {

                          CartId = cart.CartId,

                          TotalPrice = cart.TotalPrice,

                          Count = cart.Count,



                      }

               ).ToListAsync();

        }

        public async Task<Cart> UpdateCart(int Id, CartDTO cartDto)
        {
            Cart cart = new Cart
            {

                TotalPrice = cartDto.TotalPrice,
                Count = cartDto.Count
            };


            _context.Entry(cart).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return cart;
        }


        public async Task DeleteCart(int id)
        {
            Cart cart = await _context.Carts.FindAsync(id);
            if (cart != null)
            {
                _context.Entry(cart).State = EntityState.Deleted;

                await _context.SaveChangesAsync();
            }
        }


        public async Task<AnimalCart> AddAnimalToCart(int cartId, int animalId)
        {

           var animalCart1 =  _context.AnimalCarts.FirstOrDefaultAsync(x => x.CartId == cartId && x.AnimalId == animalId);
            if (animalCart1 == null) {

                return null;
            }


            AnimalCart animalCart = new AnimalCart { 
            
            AnimalId = animalId,
            CartId = cartId

            };

            _context.Entry(animalCart).State = EntityState.Added;

            await _context.SaveChangesAsync();
            return animalCart;
        }

        public async Task<CartProduct> AddproductToCart(int cartId, int productId)
        {
            CartProduct cartProduct = new CartProduct
            {

                ProdactId = productId,
                CartId = cartId

            };

            _context.Entry(cartProduct).State = EntityState.Added;

            await _context.SaveChangesAsync();
            return cartProduct;
        }


        public async Task DeleteAnimalFromCart(int cartId, int animalId)
        {
            AnimalCart animalCart = await _context.AnimalCarts.FirstOrDefaultAsync(x => x.CartId == cartId && x.AnimalId == animalId );
            if (animalCart != null)
            {
                _context.Entry(animalCart).State = EntityState.Deleted;

                await _context.SaveChangesAsync();
            }
        }
        public async Task DeleteproductFromCart(int cartId, int productId)
        {
            CartProduct cartProduct= await _context.CartProducts.FirstOrDefaultAsync(x => x.CartId == cartId && x.ProdactId == productId);
            if (cartProduct != null)
            {
                _context.Entry(cartProduct).State = EntityState.Deleted;

                await _context.SaveChangesAsync();
            }
        }
    }
}
