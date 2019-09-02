using System;
using Microsoft.AspNetCore.Mvc;
using Golowinskiy.Web.Models.Product;
using Microsoft.AspNetCore.Identity;
using Golowinskiy.Web.Entities;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Http;
using Golowinskiy.Web.Context;
using System.Collections.Generic;
using System.Linq;

namespace Golowinskiy.Web.Controllers
{
    public class ProductController : Controller
    {
        private GolowinskiyDBContext db;
        private readonly UserManager<User> _userManager;

        public ProductController(GolowinskiyDBContext context, UserManager<User> userManager)
        {
            db = context;
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
                    UserId = user.Id,
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
            var newProduct = new Product()
            {
                CategoryId = 50,
                UserId = product.UserId,
                FileName = product.MainImage.FileName,
                ProductName = product.ProductName,
                Description = product.Description,
                Price = product.Price,
                VideoLink = product.VideoLink,
                ProductType = product.ProductType,
                ProductArticle = product.ProductArticle,
                TransformationMechanism = product.TransformationMechanism
            };

            using (var fs = product.MainImage.OpenReadStream())
            {
                newProduct.Imagedata = new byte[fs.Length];
                fs.Read(newProduct.Imagedata, 0, newProduct.Imagedata.Length);
            }

            db.Products.Add(newProduct);
            db.SaveChanges();

            if(product.AdditionalImages.Count > 0)
            {
                SaveAddtImages(product.AdditionalImages);
            }

            return View();
        }

        public void SaveAddtImages(List<IFormFile> additionalImages)
        {
            int productId = 0;
            var newProduct = db.Products.LastOrDefault();
            if(newProduct != null)
            {
                productId = newProduct.Id;
            }

            var addtImages = new List<AdditionalImage>();
            foreach(var img in additionalImages)
            {
                var newImage = new AdditionalImage()
                {
                    ProductId = productId,
                    FileName = img.FileName,
                };

                using (var fs = img.OpenReadStream())
                {
                    newImage.Imagedata = new byte[fs.Length];
                    fs.Read(newImage.Imagedata, 0, newImage.Imagedata.Length);
                }

                addtImages.Add(newImage);
            }

            db.AdditionalImages.AddRange(addtImages);
            db.SaveChanges();
        }
    }
}