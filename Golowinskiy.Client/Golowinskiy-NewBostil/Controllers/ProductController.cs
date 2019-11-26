using System;
using Microsoft.AspNetCore.Mvc;
using Golowinskiy_NewBostil.Models.Product;
using Microsoft.AspNetCore.Identity;
using Golowinskiy_NewBostil.Entities;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Http;
using Golowinskiy_NewBostil.Context;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using Microsoft.EntityFrameworkCore;
using Golowinskiy_NewBostil.Models.Category;
using Microsoft.AspNetCore.Hosting;
using System.Drawing.Imaging;

namespace Golowinskiy_NewBostil.Controllers
{
    public class ProductController : Controller
    {
        private readonly GolowinskiyDBContext db;
        private readonly UserManager<User> _userManager;
        private readonly IHostingEnvironment _env;

        public ProductController(GolowinskiyDBContext context, UserManager<User> userManager, IHostingEnvironment env)
        {
            db = context;
            _userManager = userManager;
            _env = env;
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
                    UserName = user.DisplayName,
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

            if (product.MainImage != null)
            {
                await SaveMainImage(product.MainImage, lastProduct);
            }
            else
            {
                lastProduct.MainImage = "/images/noimage.png";
                db.Products.Update(lastProduct);
                db.SaveChanges();
            }

            if (product.AdditionalImages != null)
            {               
                await SaveAddtImages(product.AdditionalImages, lastProduct);
            }

            return Ok();
        }

        public async Task SaveMainImage(IFormFile image, Product currentProduct)
        {
            var webRoot = _env.ContentRootPath;
            var path = Path.Combine(webRoot, "wwwroot", "images", "products", currentProduct.Id.ToString());
            if (!Directory.Exists(path))
            {
                DirectoryInfo dir = Directory.CreateDirectory(path);
            }

            var stream = new FileStream(Path.Combine(path, image.FileName), FileMode.Create);
            stream.Position = 0;
            await image.CopyToAsync(stream);
            await stream.FlushAsync();

            currentProduct.MainImage = "/images/products/" + currentProduct.Id.ToString() + "/" + image.FileName;
            db.Products.Update(currentProduct);
            db.SaveChanges();
        }

        public async Task SaveAddtImages(List<IFormFile> additionalImages, Product currentProduct)
        {
            int productId = currentProduct.Id;
            var webRoot = _env.ContentRootPath;
            var path = Path.Combine(webRoot, "wwwroot", "images", "products", productId.ToString(), "additionalImages");
            if (!Directory.Exists(path))
            {
                DirectoryInfo dir = Directory.CreateDirectory(path);
            }

            var addtImages = new List<AdditionalImage>();
            foreach(var img in additionalImages)
            {
                var stream = new FileStream(Path.Combine(path, img.FileName), FileMode.Create);
                await img.CopyToAsync(stream);

                var newImage = new AdditionalImage()
                {
                    ProductId = productId,
                    ImageLink = "/images/products/" + currentProduct.Id.ToString() + "/additionalImages/" + img.FileName
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

            return PartialView("~/Views/Product/CategoryProducts.cshtml", productModel);
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
        public async Task<IActionResult> ProductsDetail(int categoryId, bool isChange)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            var products =  db.Products.Include(x => x.AdditionalImages).Where(x => x.CategoryId == categoryId);

            var model = new List<ProductDetailViewModel>();

            foreach(var prod in products)
            {
                List<string> addtImgs = new List<string>();
                foreach (var img in prod.AdditionalImages)
                {
                    addtImgs.Add(img.ImageLink);
                }

                var prodModel = new ProductDetailViewModel()
                {
                    Id = prod.Id,
                    ProductName = prod.ProductName,
                    Description = prod.Description,
                    Price = prod.Price,
                    MainImageLink = prod.MainImage,
                    AdditionalImagesLink = addtImgs
                };

                model.Add(prodModel);
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
                UserName = user.DisplayName,
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
                await SaveMainImage(model.MainImage, product);     
            }
            else 
            {             
                product.MainImage = "/images/noimage.png";
                db.Products.Update(product);
                db.SaveChanges();
            }

            if (model.AdditionalImages != null)
            {
                await SaveAddtImages(model.AdditionalImages, product);
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


            if (Directory.Exists(product.MainImage) && product.MainImage != "/images/noimage.png")
            {
                Directory.Delete(product.MainImage);
            }


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