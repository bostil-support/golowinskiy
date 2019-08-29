using System;
using Microsoft.AspNetCore.Mvc;
using Golowinskiy.Web.Models.Product;
using Microsoft.AspNetCore.Identity;
using Golowinskiy.Web.Entities;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace Golowinskiy.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly UserManager<User> _userManager;

        public ProductController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> AddProduct()
        {
            bool isAuthenticate = (HttpContext.User != null)
                && HttpContext.User.Identity.IsAuthenticated;

            if (isAuthenticate)
            {
                var user = await _userManager.GetUserAsync(User);

                AddProductViewModel model = new AddProductViewModel()
                {
                    UserName = user.UserName,
                    Email = user.Email
                };

                return View(model);
            }
            else
            {
                return Redirect("~/Auth/ModalWindow");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddNewProduct(AddProductViewModel product)
        {
             return View();
        }
    }
}