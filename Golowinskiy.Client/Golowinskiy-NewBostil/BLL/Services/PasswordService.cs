using Golowinskiy_NewBostil.BLL.Interfaces;
using Golowinskiy_NewBostil.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Golowinskiy_NewBostil.BLL.Services
{
    public class PasswordService : IPasswordService
    {
        private readonly UserManager<User> _userManager;

        public PasswordService(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<User> RecoveryPassword(string Email)
        {
            var user = await _userManager.FindByEmailAsync(Email);
            return user;

        }
    }
}
