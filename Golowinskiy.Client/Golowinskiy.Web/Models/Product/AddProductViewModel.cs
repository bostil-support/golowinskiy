using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Golowinskiy.Web.Models.Product
{
    public class AddProductViewModel
    {
        public string UserName { get; set; }

        public string Email { get; set; }

        public IFormFile MainPhoto { get; set; }

        public List<IFormFile> AdditionalPhoto { get; set; }

        public string ProductName { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public string VideoLink { get; set; }

        public string ProductType { get; set; }

        public string ProductArticle { get; set; }

        public string TransformationMechanism { get; set; }

    }
}
