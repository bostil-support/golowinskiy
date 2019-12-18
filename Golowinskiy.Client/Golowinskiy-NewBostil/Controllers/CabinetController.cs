using Golowinskiy_NewBostil.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Golowinskiy_NewBostil.BLL.Interfaces;
using System.Threading.Tasks;

namespace Golowinskiy_NewBostil.Controllers
{
    public class CabinetController : Controller
    {
        private readonly IAuthService _authService;

        public CabinetController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpGet]
        public IActionResult Cabinet()
        {
            bool isAuthenticate = (HttpContext.User != null)
                           && HttpContext.User.Identity.IsAuthenticated;
           
            if (isAuthenticate)
            {
                if (User.IsInRole("Admin"))
                {
                    return RedirectToAction("AdminPanel", "Admin");
                }

                return View();
            }
            else
            {
                return Redirect("~/Auth/ModalWindow");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Header()
        {
            var model = new CabinetViewModel();

            model.UserId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var name = await _authService.GetUser(model.UserId);
            model.UserName = name.DisplayName;

            return PartialView(model);
        }
    }
}