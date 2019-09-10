using System.Collections.Generic;
using Golowinskiy.Web.Models.Category;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Golowinskiy.Web.TagHelpers
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

        private void AddCategory(List<CategoryViewModel> Items, TagHelperOutput output)
        {
            if (Items.Count == 0)
            {
                return;
            }

            output.Content.AppendHtml($@"<ul class='sub-menu left-menu text-truncate'>");
            foreach (var item in Items)
            {
                if (item.ListInnerCat.Count != 0)
                {
                    output.Content.AppendHtml($@"<li class='menu-item generation nav-item active' onclick='showSubCategories(this, event)'><a href='#'>{item.Name}</a>");
                    AddCategory(item.ListInnerCat, output);
                }
                else
                {
                    output.Content.AppendHtml($@"<li class='menu-item'><a href='Product/GetProductsByCategory?categoryId={item.Id}'>{item.Name} ({item.Count})</a>");
                }

                output.Content.AppendHtml($@"</li>");
            }
            output.Content.AppendHtml($@"</ul>");
        }
    }
}
