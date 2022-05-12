using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pet_Shop.Models;
using Pet_Shop.Models.DTO;
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
        public async Task<ActionResult<IEnumerable<Cart>>> GetCarts()
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


    }
}
