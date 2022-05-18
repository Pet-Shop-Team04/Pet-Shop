using Microsoft.AspNetCore.Mvc.ModelBinding;
using Pet_Shop.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pet_Shop.Models.Interfaces
{
    public interface IUserService
    {
        public Task<ApplicationUser> Register(RegisterUserDTO data, ModelStateDictionary modelState);
        public Task<UserDTO> Login(LoginData data, ModelStateDictionary modelState);
        public Task Logout();
    }
}
