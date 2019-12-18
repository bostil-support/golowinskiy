using Microsoft.AspNetCore.Mvc;
using Golowinskiy_NewBostil.Models.Product;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Security.Claims;
using Golowinskiy_NewBostil.BLL.Interfaces;
using Golowinskiy_NewBostil.BLL.DTO;
using AutoMapper;
using Microsoft.Extensions.Hosting;

namespace Golowinskiy_NewBostil.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IAuthService _authService;
        private readonly IHostEnvironment _env;
        private readonly IMapper _mapper;

        public ProductController(
            IProductService productService,
            IAuthService authService,
            IHostEnvironment env,
            IMapper mapper)
        {
            _productService = productService;
            _authService = authService;
            _mapper = mapper;
            _env = env;
        }

        [HttpGet]
        public async Task<IActionResult> GetProductView()
        {
            bool isAuthenticate = (HttpContext.User != null)
                && HttpContext.User.Identity.IsAuthenticated;

            if (isAuthenticate)
            {
                var user = await _authService.GetUser(User.FindFirstValue(ClaimTypes.NameIdentifier));

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
            var productDto = _mapper.Map<ProductInfoDTO>(product);
            await _productService.AddProduct(productDto);

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetProductsByCategory(int categoryId)
        {
            var products = await _productService.GetProductsByCategory(categoryId);
            var productModel = _mapper.Map<List<ProductCategoryViewModel>>(products);

            ViewBag.CategoryId = categoryId;

            return PartialView("~/Views/Product/CategoryProducts.cshtml", productModel);
        }

        [HttpGet]
        public async Task<IActionResult> GetProductsByUserCategory(int categoryId)
        {
            string userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var products = await _productService.GetProductsByUserCategory(categoryId, userId);
            var productModel = _mapper.Map<List<ProductCategoryViewModel>>(products);

            ViewBag.CategoryId = categoryId;

            return PartialView("~/Views/Product/CategoryProducts.cshtml", productModel);
        }

        [HttpGet]
        public async Task<IActionResult> ProductDetailById(int id, string position, bool isChange)
        {
            var product = await _productService.GetProductDetailById(id);
            var model = _mapper.Map<ProductDetailViewModel>(product);

            if (isChange)
            {
                model.IsChange = true;
                model.Position = position;
            }

            return PartialView("~/Views/Product/ProductDetail.cshtml", model);
        }

        [HttpGet]
        public async Task<IActionResult> ProductsDetail(int categoryId, bool isChange)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var products = await _productService.GetProductsDetail(categoryId, userId, isChange);
            var model = _mapper.Map<List<ProductDetailViewModel>>(products);

            return PartialView(model);
        }

        [HttpGet]
        public async Task<IActionResult> GetEditProductView(int id)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var currentUser = await _authService.GetUser(userId);

            var product = await _productService.GetProductDetailById(id);
            if (product == null)
            {
                return NotFound();
            }

            var model = _mapper.Map<EditProductViewModel>(product);
            model.UserName = currentUser.DisplayName;

            ViewBag.IsEdit = true;

            return View("~/Views/Product/Product.cshtml", model);
        }


        [HttpPut]
        public async Task<IActionResult> EditProduct(EditProductViewModel model)
        {
            var productDto = new ProductInfoDTO();
            productDto.Id = model.Id;
            productDto.ProductName = model.ProductName;
            productDto.Description = model.Description;
            productDto.MainImage = model.MainImage;
            productDto.AdditionalImages = model.AdditionalImages;
            productDto.Price = model.Price;
            productDto.VideoLink = model.VideoLink;
            productDto.ProductType = model.ProductType;
            productDto.ProductArticle = model.ProductArticle;
            productDto.TransformationMechanism = model.TransformationMechanism;

            await _productService.EditProduct(productDto);

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var result = await _productService.DeleteProduct(id);
            if (result == false)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAddtImage(int id)
        {
            var result = await _productService.DeleteAddtImage(id);
            if (result == false)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}