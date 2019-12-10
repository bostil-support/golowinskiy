using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Golowinskiy_NewBostil.Context;
using Golowinskiy_NewBostil.Entities;
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
        GolowinskiyDBContext db;
        public AdminController(GolowinskiyDBContext context)
        {
            db = context;
        }

        public async Task<IActionResult> AdminPanel()
        {
            var users = await db.Users.ToListAsync();
            var products = await db.Products.ToListAsync();

            var model = new List<AdminPanelViewModel>();
            foreach (var user in users)
            {
                int count = products.Where(x => x.UserId == user.Id).Count();
                model.Add(new AdminPanelViewModel()
                {
                    UserId = user.Id,
                    UserName = user.UserName,
                    CountProducts = count,
                    Coefficient = products[0].Coefficient
                });
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> GetUserProducts(string userId)
        {
            var userProducts = await db.Products.Where(x => x.UserId == userId).ToListAsync();
            var productModel = new List<ProductCategoryViewModel>();

            foreach (var prod in userProducts)
            {
                productModel.Add(new ProductCategoryViewModel()
                {
                    Id = prod.Id,
                    Name = prod.ProductName,
                    Price = prod.Price,
                    MainImageLink = prod.MainImage,
                });
            }

            ViewBag.UserName = db.Users.Find(userId).UserName;
            return PartialView("~/Views/Admin/UserProducts.cshtml", productModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddCoefficient(AddCoefficientViewModel model)
        {
            var products = await db.Products.Where(x => x.UserId == model.UserId).ToListAsync();
            foreach(var item in products)
            {
                item.Coefficient = model.Coefficient;
            }

            db.Products.UpdateRange(products);
            await db.SaveChangesAsync();
            return Ok();
        }
    }
}