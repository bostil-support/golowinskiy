using Golowinskiy_NewBostil.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Golowinskiy_NewBostil.DAL.Interfaces
{
    public interface IUserRepository
    {
        Task<IdentityResult> Create();
        Task Logout();
        Task<User> GetById(int id);
        Task<User> GetByPhone(string phone);
        Task<List<User>> GetAll();
    }
}
