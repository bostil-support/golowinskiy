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
        public async Task<IActionResult> GetProductView()
        {
            bool isAuthenticate = (HttpContext.User != null)
                && HttpContext.User.Identity.IsAuthenticated;

            if (isAuthenticate)
            {
                var user = await _userManager.GetUserAsync(User);

                EditProductViewModel model = new EditProductViewModel()
                {
                    UserId = user.Id,
                    UserName = user.UserName,
                    Email = user.Email
                };

                ViewBag.IsEdit = false;

                return View("~/Views/Product/Product.cshtml", model);
            }
            else
            {
                return Redirect("~/Auth/ModalWindow");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddNewProduct(EditProductViewModel product)
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

            var lastProduct = db.Products.LastOrDefault();

            SaveMainImage(product.MainImage, lastProduct);

            if (product.AdditionalImages != null)
            {               
                SaveAddtImages(product.AdditionalImages, lastProduct);
            }

            return Ok();
        }

        public void SaveMainImage(IFormFile image, Product currentProduct)
        {
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

        public void SaveAddtImages(List<IFormFile> additionalImages, Product currentProduct)
        {
            int productId = currentProduct.Id;
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
            var productModel = new List<ProductCategoryViewModel>();

            foreach (var prod in products)
            {
                productModel.Add(new ProductCategoryViewModel()
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
            var users = db.Users.ToList();
            var currentUser = await _userManager.GetUserAsync(User);
            var product = await db.Products.Include(x => x.AdditionalImages).FirstOrDefaultAsync(x => x.Id == id);
            
            List<string> addtImgs = new List<string>();
            foreach(var img in product.AdditionalImages)
            {
                addtImgs.Add(img.ImageLink);
            }

            var model = new ProductDetailViewModel()
            {
                Id = product.Id,
                ProductName = product.ProductName,
                Description = product.Description,
                Price = product.Price,
                MainImageLink = product.MainImage,
                AdditionalImagesLink = addtImgs
            };

            if(currentUser!=null && product.UserId == currentUser.Id)
            {
                ViewBag.IsChange = true;
            }
            else
            {
                ViewBag.IsChange = false;
            }

            return PartialView(model);
        }

        [HttpGet]
        public async Task<IActionResult> GetEditProductView(int id)
        {
            var user = await _userManager.GetUserAsync(User);
            var product = await db.Products.Include(x => x.AdditionalImages).FirstOrDefaultAsync(x => x.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            Dictionary<int, string> addtImgs = new Dictionary<int, string>();
            foreach (var img in product.AdditionalImages)
            {
                addtImgs.Add(img.Id, img.ImageLink);
            }
   
            EditProductViewModel model = new EditProductViewModel()
            {
                Id = product.Id,
                CategoryId = product.CategoryId,
                UserName = user.UserName,
                Email = user.Email,
                ProductName = product.ProductName,
                Description = product.Description,
                Price = product.Price,
                MainImageLink = product.MainImage,
                AdditionalImageLinks = addtImgs,
                VideoLink = product.VideoLink,
                ProductType = product.ProductType, 
                ProductArticle = product.ProductArticle,
                TransformationMechanism = product.TransformationMechanism
            };

            ViewBag.IsEdit = true;

            return View("~/Views/Product/Product.cshtml", model);
        }
       

        [HttpPut]
        public async Task<IActionResult> EditProduct(EditProductViewModel model)
        {
            var product = await db.Products.FindAsync(model.Id);
            if (product == null)
            {
                return BadRequest();
            }

            product.ProductName = model.ProductName;
            product.Description = model.Description;
            product.Price = model.Price;
            product.VideoLink = model.VideoLink;
            product.ProductType = model.ProductType;
            product.ProductArticle = model.ProductArticle;
            product.TransformationMechanism = model.TransformationMechanism;

            db.Products.Update(product);
            await db.SaveChangesAsync();

            if(model.MainImage != null)
            {
                SaveMainImage(model.MainImage, product);
            }
            
            if (model.AdditionalImages != null)
            {
                SaveAddtImages(model.AdditionalImages, product);
            }

            return Ok();
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

        [HttpDelete]
        public async Task<IActionResult> DeleteAddtImage(int id)
        {
            var img = await db.AdditionalImages.FindAsync(id);
            if (img == null)
            {
                return NotFound();
            }

            db.AdditionalImages.Remove(img);
            await db.SaveChangesAsync();

            return NoContent();
        }
    }
}