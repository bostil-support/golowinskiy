using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Golowinskiy_NewBostil.Models.Category
{
    public class CategoryViewModel
    {
        public int Id { get; set; }

        public int ParentId { get; set; }

        public string Name { get; set; }

        public int Count { get; set; }

        public List<CategoryViewModel> ListInnerCat { get; set; } = new List<CategoryViewModel>();
    }
}
