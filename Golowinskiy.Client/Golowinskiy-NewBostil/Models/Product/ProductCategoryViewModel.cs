using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Golowinskiy_NewBostil.Models.Product
{
    public class ProductCategoryViewModel
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public string ProductName { get; set; }

        public double Price { get; set; }

        public string MainImageLink { get; set; }
    }
}
