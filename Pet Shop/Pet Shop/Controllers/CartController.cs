using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pet_Shop.Models;
using Pet_Shop.Models.DTO;
using Pet_Shop.Models.DTOs;
using Pet_Shop.Models.Interfaces;

namespace Pet_Shop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICart _cart;

        public CartController(ICart cart)
        {
            _cart = cart;
        }

        // POST: api/Cart

        [HttpPost]
        public async Task<ActionResult<Cart>> PostCart()
        {
            Cart cart = await _cart.Create();
            return Ok(cart);
        }

        // GET: api/Cart
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CartDTO2>>> GetCarts()
        {
            var carts = await _cart.GetCarts();
            return Ok(carts);
        }

        // GET: api/Cart/1
        [HttpGet("{id}")]
        public async Task<ActionResult<CartDTO>> GetCart(int id)
        {
            CartDTO cartDto = await _cart.GetCart(id);
            return Ok(cartDto);
        }

        // PUT: api/Carts/2

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCart(int id, CartDTO cartDTO)
        {
            if (id != cartDTO.CartId)
            {
                return BadRequest();
            }

            Cart cart = await _cart.UpdateCart( id,  cartDTO);
            return Ok(cart);
        }

        // DELETE: api/Cart/2
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCart(int id)
        {
            var cart = await _cart.GetCart(id);
            if (cart == null)
            {
                return NotFound();
            }


            await _cart.DeleteCart(id);
            return NoContent();

        }



        // POST: api/Cart/1/Animal/1

        [HttpPost("{CartId}/Animal/{AnimalId}")]
        public async Task<ActionResult<AnimalCart>> AddAnimal(int cartId, int animalId)
        {
            AnimalCart animalCart= await _cart.AddAnimalToCart(cartId,animalId);
            if (animalCart == null)
            {
                return Ok("this animal is add before");
            }
            else { 
            
              return Ok(animalCart);
            
            }


          
        }

        // DELETE: api/Cart/2/Animal/1
        [HttpDelete("{CartId}/Animal/{AnimalId}")]
        public async Task<IActionResult> DeleteAnimal(int cartId,int animalId)
        {
            //var cart = await _cart.GetCart(id);
            //if (cart == null)
            //{
            //    return NotFound();
            //}


            await _cart.DeleteAnimalFromCart(cartId, animalId);
            return NoContent();

        }
        // POST: api/Cart/1/Product/1

        [HttpPost("{CartId}/Product/{productId}")]
        public async Task<ActionResult<AnimalCart>> AddProduct(int cartId, int productId)
        {
            CartProduct cartProduct= await _cart.AddproductToCart(cartId, productId);
            return Ok(cartProduct);
        }

        // DELETE: api/Cart/2/Product/1
        [HttpDelete("{CartId}/Product/{productId}")]
        public async Task<IActionResult> DeleteProduct(int cartId, int productId)
        {
            //var cart = await _cart.GetCart(id);
            //if (cart == null)
            //{
            //    return NotFound();
            //}


            await _cart.DeleteproductFromCart(cartId, productId);
            return NoContent();

        }
    




        // DELETE: api/Cart/2/buy
        [HttpDelete("{CartId}/buy")]
        public async Task<IActionResult> buyProduct(int cartId)
         {
           
            try
            {

               await _cart.buy(cartId, this.ModelState);

                if (ModelState.IsValid)
                {
                    return Ok("buy done");

                }
                return BadRequest(new ValidationProblemDetails(ModelState));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }


        // DELETE: api/Cart/2/empty
        [HttpDelete("{CartId}/empty")]
     public async Task<IActionResult> emptyTheCart(int cartId)
    {
            //await _cart.emptyTheCart( cartId);

            //return NoContent();


            try
            {

                await _cart.emptyTheCart(cartId);

                if (ModelState.IsValid)
                {
                    return Ok("Registered done");

                }
                return BadRequest(new ValidationProblemDetails(ModelState));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }


        }




        // DELETE: api/Cart/2/FixCart
        [HttpDelete("{CartId}/FixCart")]
        public async Task<IActionResult> fixTheCart(int cartId)
        {
            
            try
            {

                await _cart.fixTheCart(cartId, this.ModelState);

                 if (ModelState.IsValid)
                {
                    return Ok("cart fixed");

                }
                return BadRequest(new ValidationProblemDetails(ModelState));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }



        }

        // GET: api/Cart/1/checkItems
        [HttpGet("{CartId}/checkItems")]
        public async Task<ActionResult<IEnumerable<CartDTO>>> checkItems(int cartId)
        {
           

            try
            {

                await _cart.checkItems(cartId, this.ModelState);

                if (ModelState.IsValid)
                {
                    return Ok("checkItems done");

                }
                return BadRequest(new ValidationProblemDetails(ModelState));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }


        // GET: api/Cart
        [HttpGet("{CartId}/Total")]
        public async Task<ActionResult<decimal>> getTotalAmount(int cartId)
        {


            try
            {

              var x =  await _cart.getTotalAmount(cartId);

                if (ModelState.IsValid)
                {
                    return Ok($"checkItems done{x}");

                }
                return BadRequest(new ValidationProblemDetails(ModelState));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

    }
}