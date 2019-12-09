using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Golowinskiy_NewBostil.Entities
{
    public class Product
    {
        public int Id { get; set; }

        public int CategoryId { get; set; }

        public  Category Category { get; set; }

        public string UserId { get; set; }

        public  User User { get; set; }

        public string MainImage { get; set; }

        public List<AdditionalImage> AdditionalImages { get; set; }

        public string ProductName { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public double Coefficient { get; set; }

        public string VideoLink { get; set; }

        public string ProductType { get; set; }

        public string ProductArticle { get; set; }

        public string TransformationMechanism { get; set; }
    }
}
