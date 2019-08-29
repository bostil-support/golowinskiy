using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Golowinskiy.Web.Models.Auth;
using Microsoft.AspNetCore.Identity;
using Golowinskiy.Web.Entities;
using Microsoft.AspNetCore.Http;

namespace Golowinskiy.Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        IHttpContextAccessor _httpContextAccessor;

        public AuthController(UserManager<User> userManager,
            SignInManager<User> signInManager,
            IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> LoginAsync(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _userManager.Users.FirstOrDefault(item => item.PhoneNumber == model.PhoneNumber);

                if(user == null)
                {
                    return BadRequest("Неправильный моб.номер");
                }

                var result =
                    await _signInManager.PasswordSignInAsync(user,
                    model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
                    }
                    else
                    {
                        return Ok("Вы вошли в систему как пользователь");
                    }
                }
                else
                {
                    return BadRequest("Неправильный пароль");

                }
            }
            return View("~Views/Auth/Login", model);
        }

        [HttpGet]
        public IActionResult Registration()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> RegistrationAsync(RegistrationViewModel model)
        {
            if (ModelState.IsValid)
            {
                bool IsPhoneExist = _userManager.Users.Any(item => item.PhoneNumber == model.PhoneNumber);
                if(IsPhoneExist)
                {
                    return BadRequest("Пользователь с таким номером телефона уже существует");
                }

                User user = new User
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber
                };

                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, false);
                    return Ok("Вы зарегистрированы успешно");
                }
                else
                {
                    return BadRequest(result.Errors.ElementAt(0).Code);
                }
            }
            return View("~Views/Auth/Registration", model);
        }

        [HttpGet]
        public IActionResult ModalWindow()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Recovery()
        {
            return PartialView();
        }
    }
}