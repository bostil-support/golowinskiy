using System.Collections.Generic;

namespace Golowinskiy_NewBostil.DAL.Entities
{
    public class Product
    {
        public int Id { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }

        public string MainImage { get; set; }

        public List<AdditionalImage> AdditionalImages { get; set; }

        public string ProductName { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public string VideoLink { get; set; }

        public string ProductType { get; set; }

        public string ProductArticle { get; set; }

        public string TransformationMechanism { get; set; }
    }
}
