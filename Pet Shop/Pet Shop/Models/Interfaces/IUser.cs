using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pet_Shop.Models.Interfaces
{
    interface IUser
    {
        Task<Animal> Create(User user);
        Task<Animal> GetUser(int Id);
        Task<List<Animal>> GetUsers();
        Task<Animal> UpdateUser(int Id, User user);
        Task DeleteUser(int Id);
    }
}
