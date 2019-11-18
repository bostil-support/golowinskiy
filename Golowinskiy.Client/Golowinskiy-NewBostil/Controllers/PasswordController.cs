using System.Threading.Tasks;
using Golowinskiy_NewBostil.Context;
using Golowinskiy_NewBostil.Entities;
using Golowinskiy_NewBostil.Models.Password;
using Golowinskiy_NewBostil.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Golowinskiy_NewBostil.Controllers
{
    public class PasswordController : Controller
    {
        private GolowinskiyDBContext db;
        private readonly UserManager<User> _userManager;
        public PasswordController(GolowinskiyDBContext context, UserManager<User> userManager)
        {
            db = context;
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> RecoveryPassword(PasswordRecoveryViewModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user == null)
            {
                return Ok(new
                {
                    Message = "Пользователь не найден!",
                    Founded = false
                });
            }
            else
            {
                EmailService emailService = new EmailService();
                await emailService.SendEmailAsync(model.Email, "Востановление пароля Головинский", "Password");
                return Ok(new
                {
                    Message = $"Ваш пароль отправлен на email: { model.Email }",
                    Founded = true
                });
            }
        }
    }
}