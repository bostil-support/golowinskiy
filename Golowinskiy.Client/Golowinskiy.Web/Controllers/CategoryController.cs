using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Golowinskiy.Web.Context;
using Golowinskiy.Web.Entities;
using Golowinskiy.Web.Models.Category;
using Microsoft.AspNetCore.Mvc;

namespace Golowinskiy.Web.Controllers
{
    public class CategoryController : Controller
    {
        private GolowinskiyDBContext db;

        public CategoryController(GolowinskiyDBContext context)
        {
            db = context;
        }

        public IActionResult GetCategories()
        {
            var categories = db.Categories.ToList();
            List<CategoryViewModel> outputCategories = new List<CategoryViewModel>();

            foreach (var item in categories)
            {
                outputCategories.Add(new CategoryViewModel()
                {
                    Id = item.Id,
                    ParentId = item.ParentId,
                    Name = item.Name
                });
            }

            var output = GenerateCategories(outputCategories);

            return View("~/Views/Category/Categories", output);
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
    }
}