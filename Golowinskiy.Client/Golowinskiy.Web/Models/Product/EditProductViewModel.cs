using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Golowinskiy.Web.Models.Product
{
    public class EditProductViewModel : ProductDetailViewModel
    {
        //public int Id { get; set; }

        public int CategoryId { get; set; }

        public string UserId { get; set; }

        public string UserName { get; set; }

        //public string Email { get; set; }

        //public string ProductName { get; set; }

        //public string Description { get; set; }

        //public double Price { get; set; }

        //public string VideoLink { get; set; }

        //public string ProductType { get; set; }

        //public string ProductArticle { get; set; }

        //public string TransformationMechanism { get; set; }

        //public string MainImageLink { get; set; }

        public Dictionary<int, string> AdditionalImageLinks { get; set; }

        public IFormFile MainImage { get; set; }

        public List<IFormFile> AdditionalImages { get; set; }
    }
}
