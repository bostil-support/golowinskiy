using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Golowinskiy_NewBostil.Entities
{
    public class Category
    {
        public int Id { get; set; }

        public int ParentId { get; set; }

        public string Name { get; set; }

        public  List<Product> Products { get; set; }
    }
}
