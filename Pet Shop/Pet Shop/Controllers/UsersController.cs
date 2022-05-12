using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pet_Shop.Models.DTOs;
using Pet_Shop.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pet_Shop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _user;

        public UsersController(IUserService user)
        {
            _user = user;
        }

        [HttpPost("Login")]
        public async Task<ActionResult> Login(LoginData data)
        {
            try
            {
                var result = await _user.Login(data, this.ModelState);
                if (result == null)
                {
                    return BadRequest("Username or password is wrong!");
                }

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok(data);

        }

        [HttpPost("Register")]
        public async Task<ActionResult> Register(RegisterUserDTO data)
        {
            try
            {
                await _user.Register(data, this.ModelState);
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
    }
}
