using System.Threading.Tasks;
using Golowinskiy_NewBostil.BLL.Interfaces;
using Golowinskiy_NewBostil.BLL.Services;
using Golowinskiy_NewBostil.Models.Password;
using Microsoft.AspNetCore.Mvc;

namespace Golowinskiy_NewBostil.Controllers
{
    public class PasswordController : Controller
    {
        private readonly IPasswordService _passwordService;
        private readonly IEmailSender _emailService;
        public PasswordController(IPasswordService passwordService, IEmailSender emailService)
        {
            _passwordService = passwordService;
            _emailService = emailService;
        }

        [HttpPost]
        public async Task<IActionResult> RecoveryPassword(PasswordRecoveryViewModel model)
        {
            var user = await _passwordService.RecoveryPassword(model.Email);
            if (user == null)
            {
                return BadRequest(new
                {
                    Message = "Пользователь с данным email не найден!",
                    Founded = false
                });
            }
            else
            {
                await _emailService.SendEmailAsync(model.Email, "Востановление пароля Головинский", "Ваш пароль: " +  user.DisplayPassword);
                return Ok(new
                {
                    Message = $"Ваш пароль отправлен на email: { model.Email }",
                    Founded = true
                });
            }
        }
    }
}