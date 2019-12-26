using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Golowinskiy_NewBostil.Models.Category;
using Golowinskiy_NewBostil.BLL.Interfaces;

namespace Golowinskiy_NewBostil.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _service;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await _service.GetAllCategories();
            List<CategoryViewModel> outputCategories = new List<CategoryViewModel>();
            outputCategories = _mapper.Map<List<CategoryViewModel>>(categories);

            return PartialView("~/Views/Category/Categories.cshtml", outputCategories);
        }

        [HttpGet]
        public async Task<IActionResult> GetNotNullCategories()
        {
            var categories = await _service.GetNotNullCategories();
            List<CategoryViewModel> outputCategories = new List<CategoryViewModel>();
            outputCategories = _mapper.Map<List<CategoryViewModel>>(categories);

            return PartialView("~/Views/Category/Categories.cshtml", outputCategories);
        }

        [HttpGet]
        public async Task<IActionResult> GetCategoriesByUser()
        {
            string userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userCategories = await _service.GetUserCategory(userId);

            List<CategoryViewModel> outputCategories = new List<CategoryViewModel>();
            outputCategories = _mapper.Map<List<CategoryViewModel>>(userCategories);

            return PartialView("~/Views/Category/Categories.cshtml", outputCategories);
        }

        public async Task<IActionResult> BreadCrumbs(int categoryId, bool action)
        {
            var breadCrumbsDto = await _service.GetBreadCrumbs(categoryId);

            List<BreadCrumbViewModel> breadCrumbs = new List<BreadCrumbViewModel>();
            breadCrumbs = _mapper.Map<List<BreadCrumbViewModel>>(breadCrumbsDto);

            ViewBag.IsAddProduct = action;
            breadCrumbs.Reverse();

            return PartialView(breadCrumbs);
        }
    }
}