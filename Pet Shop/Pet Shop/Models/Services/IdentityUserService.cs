using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Pet_Shop.Models.DTOs;
using Pet_Shop.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pet_Shop.Models.Services
{
    public class IdentityUserService : IUserService
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private RoleManager<IdentityRole> _roleManager;


        public IdentityUserService(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public async Task<UserDTO> Login(LoginData data, ModelStateDictionary modelState)
        {
            var user = await _userManager.FindByNameAsync(data.UserName);

            if (user == null)
            {
                return null;
            }

            var result = await _signInManager.PasswordSignInAsync(user, data.Password, false, false);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);
                return new UserDTO
                {
                    Id = user.Id,
                    Username = user.UserName
                };
            }

            modelState.AddModelError(string.Empty, "Invalid Login");
            return null;
        }

        public async Task<ApplicationUser> Register(RegisterUserDTO data, ModelStateDictionary modelState)
        {
            //throw new NotImplementedException();

            var user = new ApplicationUser
            {
                UserName = data.Username,
                Email = data.Email,
            };

            var result = await _userManager.CreateAsync(user, data.Password);

            if (result.Succeeded)
            {
                return user;
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    var errorKey =
                        error.Code.Contains("Password") ? nameof(data.Password) :
                        error.Code.Contains("Email") ? nameof(data.Email) :
                        error.Code.Contains("UserName") ? nameof(data.Username) :
                        "";
                    modelState.AddModelError(errorKey, error.Description);
                }
                return null;
            }
        }
        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
