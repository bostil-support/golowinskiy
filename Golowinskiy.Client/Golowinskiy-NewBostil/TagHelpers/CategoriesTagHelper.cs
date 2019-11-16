using System;
using System.Collections.Generic;
using Golowinskiy_NewBostil.Models.Category;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Golowinskiy_NewBostil.TagHelpers
{
    public class CategoriesTagHelper : TagHelper
    {
        public List<CategoryViewModel> Items { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";

            AddCategory(Items, output);
            output.TagMode = TagMode.StartTagAndEndTag;
        }

        private void AddCategory(List<CategoryViewModel> items, TagHelperOutput output)
        {
            if (items.Count == 0)
            {
                return;
            }
            
            output.Content.AppendHtml($@"<ul class='sub-menu left-menu text-truncate'>");
            foreach (var item in items)
            {
                if (item.ListInnerCat.Count != 0)
                { 
                    output.Content.AppendHtml($@"<li class='menu-item generation nav-item active' id='{item.Id}' onclick='showSubCategories(this, event)'><a href='#'>{item.Name}</a>");
                    AddCategory(item.ListInnerCat, output);
                }
                else
                {
                    output.Content.AppendHtml($@"<li class='menu-item active' id='{item.Id}' onclick='categoryClick(this, {item.Id}, event)'><a>{item.Name} <span class='product-count'>({item.Count})</span></a>");
                }

                output.Content.AppendHtml($@"</li>");
            }
            output.Content.AppendHtml($@"</ul>");
        }
    }
}
