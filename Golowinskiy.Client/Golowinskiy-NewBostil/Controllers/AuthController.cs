using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Golowinskiy_NewBostil.Models.Auth;
using Golowinskiy_NewBostil.BLL.DTO;
using Golowinskiy_NewBostil.BLL.Interfaces;
using AutoMapper;

namespace Golowinskiy_NewBostil.Controllers
{
    public class AuthController : Controller
    {
        IAuthService _authService;
        private readonly IMapper _mapper;

        public AuthController(IAuthService authService,
            IMapper mapper)
        {
            _authService = authService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return PartialView();
        }

        [HttpPost]
        [Route("Auth/LoginAsync")]
        public async Task<IActionResult> LoginAsync(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var loginDto = _mapper.Map<LoginDTO>(model);
                var result = await _authService.LoginAsync(loginDto);

                if (result == null)
                {
                    return BadRequest("Введены неверные данные");
                }

                else
                {
                    //if (User.IsInRole("Admin"))
                    //{
                        return Ok("Вы вошли в систему как пользователь");
                    //}
                    //else
                    //{
                    //    return Ok("Вы вошли в систему как администратор");
                    //}

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
        [Route("Auth/RegistrationAsync")]
        public async Task<IActionResult> RegistrationAsync(RegistrationViewModel model)
        {
            if (ModelState.IsValid)
            {
                var registrationDto = _mapper.Map<RegistrationDTO>(model);
                var result = await _authService.RegistrationAsync(registrationDto);

                if (result == null)
                {
                    return BadRequest("Пользователь с таким номером телефона уже существует");
                }

                else
                {
                    return Ok("Вы зарегистрированы успешно");

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
            await _authService.LogOut();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Recovery()
        {
            return PartialView();
        }
    }
}