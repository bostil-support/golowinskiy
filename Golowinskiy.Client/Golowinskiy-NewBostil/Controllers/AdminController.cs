using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Golowinskiy_NewBostil.BLL.Interfaces;
using Golowinskiy_NewBostil.Models.Admin;
using Golowinskiy_NewBostil.Models.Product;
using Golowinskiy_NewBostil.Views.Admin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Golowinskiy_NewBostil.Controllers
{
   [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IAuthService _authService;
        private readonly IProductService _productService;
        
        public AdminController(IAuthService authService, IProductService productService)
        {
            _authService = authService;
            _productService = productService;
        }

        public async Task<IActionResult> AdminPanel()
        {
            var users = await _authService.GetAll();
            var productsDto = await _productService.GetAllProducts();

            var model = new List<AdminPanelViewModel>();
            foreach (var user in users)
            {
                int count = productsDto.Where(x => x.UserId == user.Id).Count();
                model.Add(new AdminPanelViewModel()
                {
                    UserId = user.Id,
                    UserName = user.UserName,
                    CountProducts = count,
                    Coefficient = user.Coefficient
                });
            }

            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> Header()
        {
            var model = new AdminPanelViewModel();

            model.UserId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var name = await _authService.GetUser(model.UserId);
            model.UserName = name.DisplayName;

            return PartialView(model);
        }

        [HttpGet]
        public async Task<IActionResult> GetUserProducts(string userId)
        {
            var userProductsDto = await _productService.GetProductsByUser(userId);
            var productModel = new List<ProductCategoryViewModel>();

            foreach (var prod in userProductsDto)
            {
                productModel.Add(new ProductCategoryViewModel()
                {
                    Id = prod.Id,
                    ProductName = prod.ProductName,
                    Price = prod.Price,
                    MainImageLink = prod.MainImageLink,
                });
            }

            ViewBag.UserName = _authService.GetUserName(userId);
            return PartialView("~/Views/Admin/UserProducts.cshtml", productModel);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCoefficient(AddCoefficientViewModel model)
        {
            await _authService.UpdateCoefficient(model.Coefficient, model.UserId);
            return Ok();
        }
    }
}