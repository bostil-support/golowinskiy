using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Golowinskiy_NewBostil.Entities;
using Golowinskiy_NewBostil.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace Golowinskiy_NewBostil.Controllers
{
    public class CabinetController : Controller
    {
        private readonly UserManager<User> _userManager;
        public CabinetController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Cabinet()
        {
            bool isAuthenticate = (HttpContext.User != null)
                           && HttpContext.User.Identity.IsAuthenticated;
           
            if (isAuthenticate)
            {
                return View();
            }
            else
            {
                return Redirect("~/Auth/ModalWindow");
            }
        }

        [HttpGet]
        public IActionResult Header()
        {
            var model = new CabinetViewModel();
            model.UserId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = _userManager.FindByIdAsync(model.UserId);
            model.UserName = user.Result.DisplayName;
            return PartialView(model);
        }
    }
}