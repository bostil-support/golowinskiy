using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Golowinskiy_NewBostil.Context;
using Golowinskiy_NewBostil.Entities;
using Golowinskiy_NewBostil.Models.Product;
using Microsoft.AspNetCore.Mvc;

namespace Golowinskiy_NewBostil.Controllers
{
    public class AdminController : Controller
    {
        GolowinskiyDBContext db;

        public AdminController(GolowinskiyDBContext context)
        {
            db = context;
        }

        public IActionResult AdminPanel()
        {
            var users = db.Users.ToList();
            var products = db.Products.ToList();

            Dictionary<User, int> userDict = new Dictionary<User, int>();
            foreach(var user in users)
            {
                int count = products.Where(x => x.UserId == user.Id).Count();
                userDict.Add(user, count);
            }

            return View(userDict);
        }

        public IActionResult GetUserProducts(string userId)
        {
            var userProducts = db.Products.Where(x => x.UserId == userId);
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
    }
}