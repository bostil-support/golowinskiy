using Golowinskiy_NewBostil.BLL.DTO;
using Golowinskiy_NewBostil.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Golowinskiy_NewBostil.BLL.Interfaces
{
    public interface IAuthService
    {
        Task<SignInResult> LoginAsync(LoginDTO loginDto);
        Task<string> RegistrationAsync(RegistrationDTO registrationDto);
        Task LogOut();
        Task<User> GetUser(string id);
        Task<string> GetUserName(string id);
        Task<List<User>> GetAll();
        Task<double> GetCoefficient(string userId);
        Task UpdateCoefficient(double coefficient, string userId);
    }
}
