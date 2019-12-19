using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Golowinskiy_NewBostil.BLL.DTO
{
    public class ProductInfoDTO : ProductDTO
    {
        public int CategoryId { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Description { get; set; }
        public string VideoLink { get; set; }
        public string ProductType { get; set; }
        public string ProductArticle { get; set; }
        public string TransformationMechanism { get; set; }
        public List<string> AdditionalImagesLinks { get; set; }
        public IFormFile MainImage { get; set; }
        public List<IFormFile> AdditionalImages { get; set; }
        public Dictionary<int, string> AdditionalDictImagesLinks { get; set; }
        public bool IsChange { get; set; }
    }
}
