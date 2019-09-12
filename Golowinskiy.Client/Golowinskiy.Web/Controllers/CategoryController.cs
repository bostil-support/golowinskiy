using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Golowinskiy.Web.Context;
using Golowinskiy.Web.Entities;
using Golowinskiy.Web.Models.Category;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Golowinskiy.Web.Controllers
{
    public class CategoryController : Controller
    {
        private GolowinskiyDBContext db;

        public CategoryController(GolowinskiyDBContext context)
        {
            db = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await db.Categories.Include(x => x.Products).ToListAsync();
            List<CategoryViewModel> outputCategories = new List<CategoryViewModel>();

            foreach (var item in categories)
            {
                outputCategories.Add(new CategoryViewModel()
                {
                    Id = item.Id,
                    ParentId = item.ParentId,
                    Name = item.Name,
                    Count = item.Products.Count
                });
            }
            
            var output = GenerateCategories(outputCategories);
            return PartialView("~/Views/Category/Categories.cshtml", output);
        }

        [HttpGet]
        public async Task<IActionResult> GetCategoriesByUser()
        {
            string userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var products = db.Products.Include(x => x.AdditionalImages).ToList();
            var userCategory = await db.Categories.Where(x => x.Products.Count > 0 && x.Products.Any(y => y.UserId == userId)).Include(x => x.Products).ToListAsync();
            var categories = GenerateUserCategory(userCategory);

            List<CategoryViewModel> outputCategories = new List<CategoryViewModel>();

            foreach (var item in categories)
            {
                outputCategories.Add(new CategoryViewModel()
                {
                    Id = item.Id,
                    ParentId = item.ParentId,
                    Name = item.Name,
                    Count = item.Products.Count
                });
            }

            var output = GenerateCategories(outputCategories);

            return PartialView("~/Views/Category/Categories.cshtml", output);
        }

        public List<CategoryViewModel> GenerateCategories(List<CategoryViewModel> listOnputModel)
        {
            List<CategoryViewModel> parentsCategories = (
                from a in listOnputModel
                where a.ParentId == 0
                select a).ToList();

            foreach (var parentCat in parentsCategories)
            {
                if (parentsCategories.Count > 0)
                {
                    AddChildItem(parentCat, listOnputModel);
                }
                else
                {
                    continue;
                }
            }
            return parentsCategories;
        }

        private void AddChildItem(CategoryViewModel parentItem, List<CategoryViewModel> listAllCategories)
        {
            List<CategoryViewModel> childItems = (
                from a in listAllCategories
                where a.ParentId == parentItem.Id
                select a).ToList();
            foreach (var childItem in childItems)
            {
                if (childItems.Count > 0)
                {
                    parentItem.ListInnerCat.Add(childItem);
                    AddChildItem(childItem, listAllCategories);
                }
                else
                {
                    continue;
                }
            }
        }

        public List<Category> GenerateUserCategory(List<Category> categories)
        {
            List<Category> outputCategories = new List<Category>();

            foreach(var category in categories)
            {
                outputCategories = AddUserCategories(outputCategories, category.Id);
            }

            return outputCategories;
        }

        public List<Category> AddUserCategories(List<Category> outputCategories, int parentId)
        {
            while (parentId > 0)
            {
                var parentCategory = db.Categories.Include(x => x.Products).FirstOrDefault(x => x.Id == parentId);

                if (!outputCategories.Contains(parentCategory))
                {
                    outputCategories.Add(parentCategory);
                    parentId = parentCategory.ParentId;
                }
                else
                {
                    break;
                }
            }

            return outputCategories;
        }
    }
}