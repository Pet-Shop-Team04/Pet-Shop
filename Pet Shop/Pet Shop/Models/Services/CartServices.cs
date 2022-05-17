using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Pet_Shop.Data;
using Pet_Shop.Models.DTO;
using Pet_Shop.Models.DTOs;
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
        
        public async Task<CartDTO> GetCart(int CartId)
        {
           // decimal newTotalPrice =  getTotalAmount(CartId).Result;

            return await _context.Carts.Select(

                   cart => new CartDTO
                     {

                         CartId = cart.CartId,

                         TotalPrice = getTotalAmount(CartId).Result,

                         Animals = cart.AnimalCarts.Select(animalcart => new AnimalForCartDto
                         { 

                            AnimalId = animalcart.Animal.AnimalId,                         
                         Name= animalcart.Animal.Name,

                         Price = animalcart.Animal.Price

                         }).ToList(),


                         Products = cart.CartProducts.Select(cartProducts => new ProductForCartDto
                         {

                            ProdactId  = cartProducts.Prodact.ProductId,
                             Name = cartProducts.Prodact.Name,

                             Price = cartProducts.Prodact.Price,
                             Amount = cartProducts.Amount
                         }).ToList()



                   }

              ).FirstOrDefaultAsync(x => x.CartId == CartId); 

        }

        public async Task<List<CartDTO2>> GetCarts()
        {

            List<Cart> carts = await _context.Carts.ToListAsync();

            //var x=await _context.Carts.Select(

            //        cart =>                  
            //        new CartDTO
            //        {
            //            CartId = cart.CartId,
            //           TotalPrice = getTotalAmount(cart.CartId).Result,
            //            Count = cart.Count,
            //        }

            // ).ToListAsync();

            List<CartDTO2> cartDTOs = new List<CartDTO2>();
            foreach (Cart cart in carts)
            {
                var cartDTO = new CartDTO2
                {
                    CartId = cart.CartId,

                    TotalPrice = getTotalAmount(cart.CartId).Result,



                };

                cartDTOs.Add(cartDTO);
            }
          
            return cartDTOs;
        }

        public async Task<Cart> UpdateCart(int Id, CartDTO cartDto)
        {
            Cart cart = new Cart
            {

                TotalPrice = cartDto.TotalPrice,
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

        public async Task<CartDTO> checkItems(int cartId, ModelStateDictionary modelState)
        {

            List<AnimalCart> animalList = await _context.AnimalCarts.Where(x => x.CartId == cartId).Include(x => x.Animal).ToListAsync();
            List<CartProduct> productsList = await _context.CartProducts.Where(x => x.CartId == cartId).Include(x => x.Prodact).ToListAsync();

            foreach (var item in animalList)
            {
                if (await _context.Animals.FirstOrDefaultAsync(x => x.AnimalId == item.AnimalId) == null)
                {
                    modelState.AddModelError("Animal not found", $"Animal with {item.AnimalId} not found");
                }

            }



            foreach (var item in productsList)
            {
                Product item2 = await _context.Products.FirstOrDefaultAsync(x => x.ProductId == item.ProdactId);
                if (item2 == null)
                {
                    modelState.AddModelError("Product Not Found", $"product with {item.ProdactId} not found OR already sold");
                }
                if (item2.Amount < item.Amount)
                {
                    modelState.AddModelError("Limit Error", $"No amount in app of this product");

                }


            }

            return null;

        }
        public async Task<CartDTO> fixTheCart(int cartId, ModelStateDictionary modelState)

        {

            List<AnimalCart> animalList = await _context.AnimalCarts.Where(x => x.CartId == cartId).Include(x => x.Animal).ToListAsync();
            List<CartProduct> productsList = await _context.CartProducts.Where(x => x.CartId == cartId).Include(x => x.Prodact).ToListAsync();

            foreach (AnimalCart item in animalList)
            {
                if (await _context.Animals.FirstOrDefaultAsync(x => x.AnimalId == item.AnimalId) == null)
                {
                    int animalId2 = item.AnimalId;
                    DeleteAnimalFromCart(cartId, animalId2);
                   modelState.AddModelError("item deleted",$"animal with id {animalId2} delete from the cart , because your order is more than the capacity left in the shop");

                    //AnimalServices x= new AnimalServices();
                    //x.DeleteAnimal(animalId2);

                }
                


            }

            foreach (CartProduct item in productsList)
            {
                Product item2 = await _context.Products.FirstOrDefaultAsync(x => x.ProductId == item.ProdactId);
                if (item2 == null)
                {
                    DeleteproductFromCart(cartId, item.ProdactId);
                    modelState.AddModelError("item deleted", $"product with id {item.ProdactId} delete from the cart");

                }
                //else { modelState.AddModelError("Cart Error ", "something not ok2");  }


                if (item2.Amount < item.Amount)
                {
                    DeleteproductFromCart(cartId, item.ProdactId);
                    modelState.AddModelError("item deleted", $"product with id {item.ProdactId} delete from the cart");

                }



            }

            return null;

            //ifsucces


        }

        public async Task<decimal> getTotalAmount(int cartId) {

            decimal total = 0;
          //  Cart ListItem = await _context.Carts.Where(x => x.CartId == cartId).Include(x => x.AnimalCarts ).ThenInclude(x => x.Animal).Include(x => x.CartProducts ).FirstOrDefaultAsync();

            List<AnimalCart> animalList = await _context.AnimalCarts.Where(x => x.CartId == cartId).Include(x=> x.Animal).ToListAsync();
            List<CartProduct> productsList = await _context.CartProducts.Where(x => x.CartId == cartId).Include(x => x.Prodact).ToListAsync();


            foreach (AnimalCart item in animalList)
            {
                var x = item.Animal.Price;
                if (x != null)
                {

                    total += item.Animal.Price;
                }

            }

            foreach (CartProduct item in productsList)
            {
                var x = item.Prodact.Price;
                if (x != null)
                {
                    total += item.Prodact.Price * item.Amount;
                }


            }

            return total;

        }

      

        public async Task emptyTheCart(int cartId)
        {
            List<AnimalCart> animalList = await _context.AnimalCarts.Where(x => x.CartId == cartId).ToListAsync();
            List<CartProduct> productsList = await _context.CartProducts.Where(x => x.CartId == cartId).ToListAsync();


            foreach (AnimalCart item in animalList)
            {

                DeleteproductFromCart(cartId, item.AnimalId);

            }

            foreach (CartProduct item in productsList)
            {
                DeleteproductFromCart(cartId, item.ProdactId);


            }



        }


        public async Task buy(int cartId, ModelStateDictionary modelState)
        {

             checkItems(cartId, modelState);

            if (modelState.IsValid)
            {
                  emptyTheCart(cartId);
            }
            else {

                modelState.AddModelError("item deleted", $"product delete from the cart");
                
            }

        }
    }
}
