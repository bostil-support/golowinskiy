using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Golowinskiy_NewBostil.BLL.DTO
{
    public class AdditionalImageDTO
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public string ImageLink { get; set; }
    }
}
