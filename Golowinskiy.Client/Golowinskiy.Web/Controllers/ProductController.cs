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
using Microsoft.EntityFrameworkCore;
using Golowinskiy.Web.Models.Category;

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
        public async Task<IActionResult> GetAddProductView()
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

                return View("~/Views/Product/AddProduct.cshtml", model);
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
                CategoryId = product.CategoryId,
                UserId = product.UserId,
                ProductName = product.ProductName,
                Description = product.Description,
                Price = product.Price,
                VideoLink = product.VideoLink,
                ProductType = product.ProductType,
                ProductArticle = product.ProductArticle,
                TransformationMechanism = product.TransformationMechanism
            };

            await db.Products.AddAsync(newProduct);
            await db.SaveChangesAsync();

            SaveMainImage(product.MainImage);

            if (product.AdditionalImages != null)
            {
                SaveAddtImages(product.AdditionalImages);
            }

            return Ok();
        }

        public void SaveMainImage(IFormFile image)
        {
            var currentProduct = db.Products.LastOrDefault();

            var path = Path.Combine("wwwroot", "images", "products", currentProduct.Id.ToString());
            if (!Directory.Exists(path))
            {
                DirectoryInfo dir = Directory.CreateDirectory(path);
            }

            var stream = new FileStream(Path.Combine(path, image.FileName), FileMode.Create);
            image.CopyToAsync(stream);

            currentProduct.MainImage = path.Remove(0, 7).Replace('\\','/') + '/'  + image.FileName;
            db.Products.Update(currentProduct);
            db.SaveChanges();
        }

        public void SaveAddtImages(List<IFormFile> additionalImages)
        {
            int productId = 0;
            var newProduct = db.Products.LastOrDefault();
            if(newProduct != null)
            {
                productId = newProduct.Id;
            }

            var path = Path.Combine("wwwroot", "images", "products", productId.ToString(), "additionalImages");
            if (!Directory.Exists(path))
            {
                DirectoryInfo dir = Directory.CreateDirectory(path);
            }

            var addtImages = new List<AdditionalImage>();
            foreach(var img in additionalImages)
            {
                var stream = new FileStream(Path.Combine(path, img.FileName), FileMode.Create);
                img.CopyToAsync(stream);

                var newImage = new AdditionalImage()
                {
                    ProductId = productId,
                    ImageLink = path.Remove(0, 7).Replace('\\', '/') + '/' + img.FileName
                };

                addtImages.Add(newImage);
            }

            db.AdditionalImages.AddRange(addtImages);
            db.SaveChanges();
        }

        [HttpGet]
        public async Task<IActionResult> GetProductsByCategory(int categoryId)
        {
            var products = await db.Products.Where(x => x.CategoryId == categoryId).Include(x => x.User).ToListAsync();
            var productModel = new List<ProductViewModel>();

            foreach (var prod in products)
            {                
                productModel.Add(new ProductViewModel()
                {
                    Id = prod.Id,
                    Name = prod.ProductName,
                    Price = prod.Price,
                    MainImageLink = prod.MainImage
            });
            }

            ViewBag.CategoryId = categoryId;

            return View("~/Views/Product/CategoryProducts.cshtml", productModel);
        }

        public IActionResult BreadCrumbs(int categoryId, bool action)
        {
            List<BreadCrumbViewModel> model = new List<BreadCrumbViewModel>();
            model = GetCategoryList(model, categoryId);
            ViewBag.IsAddProduct = action;
            model.Reverse();

            return PartialView(model);
        }

        public List<BreadCrumbViewModel> GetCategoryList(List<BreadCrumbViewModel> categoryNames, int categoryId)
        {
            var category = db.Categories.FirstOrDefault(x => x.Id == categoryId);
            categoryNames.Add(new BreadCrumbViewModel() { Id = category.Id, Name = category.Name });

            if(category.ParentId != 0)
            {
                GetCategoryList(categoryNames, category.ParentId);
            }

            return categoryNames;
        }

        [HttpGet]
        public async Task<IActionResult> ProductDetail(int id)
        {
            var uses = db.Users.ToList();
            var product = await db.Products.Include(x => x.AdditionalImages).FirstOrDefaultAsync(x => x.Id == id);

            List<string> addtImgs = new List<string>();
            foreach(var img in product.AdditionalImages)
            {
                addtImgs.Add(img.ImageLink);
            }

            var model = new ProductDetailViewModel()
            {
                Id = product.Id,
                Email = product.User.Email,
                Phone = product.User.PhoneNumber,
                ProductName = product.ProductName,
                Description = product.Description,
                Price = product.Price,
                MainImageLink = product.MainImage,
                AdditionalImagesLink = addtImgs
            };

            return PartialView(model);
        }

        [HttpGet]
        public async Task<IActionResult> EditProduct(int id)
        {
            var user = await _userManager.GetUserAsync(User);
            var product = await db.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            EditProductViewModel model = new EditProductViewModel()
            {
                UserName = user.UserName,
                Email = user.Email,
                ProductName = product.ProductName,
                Description = product.Description,
                Price = product.Price,
                MainImageLink = product.MainImage,
                VideoLink = product.VideoLink,
                ProductType = product.ProductType, 
                ProductArticle = product.ProductArticle,
                TransformationMechanism = product.TransformationMechanism
            };

            return View(model);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await db.Products.FindAsync(id);
            if(product == null)
            {
                return NotFound();
            }

            db.Products.Remove(product);
            await db.SaveChangesAsync();

            return NoContent();
        }
    }
}