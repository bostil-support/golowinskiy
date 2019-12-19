using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Golowinskiy_NewBostil.BLL.DTO;
using Golowinskiy_NewBostil.BLL.Interfaces;
using Golowinskiy_NewBostil.DAL.Context;
using Golowinskiy_NewBostil.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Golowinskiy_NewBostil.BLL.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly GolowinskiyDBContext _db;
        private readonly IMapper _mapper;

        public AuthService(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            GolowinskiyDBContext db,
            IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _db = db;
        }
        public async Task<SignInResult> LoginAsync(LoginDTO loginDto)
        {
            var user = _userManager.Users.FirstOrDefault(item => item.PhoneNumber == loginDto.PhoneNumber);

            if (user == null)
            {
                return null;
            }

            var result = await _signInManager.PasswordSignInAsync(user, loginDto.Password, true, false);

            if (result.Succeeded)
            {
                return result;
            }
            else
            {
                return null;

            }
        }

        public async Task<IdentityResult> RegistrationAsync(RegistrationDTO registrationDto)
        {
            bool IsPhoneExist = _userManager.Users.Any(item => item.PhoneNumber == registrationDto.PhoneNumber);
            
            if (IsPhoneExist)
            {
                return null;
            }

            User user = _mapper.Map<User>(registrationDto);
            var userName = await _userManager.FindByNameAsync(registrationDto.UserName);

            if (userName != null)
            {
                user.UserName = registrationDto.UserName + Guid.NewGuid();
            }

            var result = await _userManager.CreateAsync(user, registrationDto.Password);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);
            }

            return result;
        }

        public async Task LogOut()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<User> GetUser(string id)
        {
           var user = await _userManager.FindByIdAsync(id);
           return user;
        }

        public async Task<List<User>> GetAll()
        {
            return await _db.Users.ToListAsync();
        }

        public async Task<string> GetUserName(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            return user.DisplayName;
        }

        public async Task UpdateCoefficient(double coefficient, string userId)
        {
            var user = await GetUser(userId);
            user.Coefficient = coefficient;
            _db.Update(user);
            await _db.SaveChangesAsync();
        }

        public async Task<double> GetCoefficient(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            return user.Coefficient;
        }
    }
}
