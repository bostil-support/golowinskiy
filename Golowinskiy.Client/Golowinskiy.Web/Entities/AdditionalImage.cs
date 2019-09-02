using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Golowinskiy.Web.Entities
{
    public class AdditionalImage
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }

        public string FileName { get; set; }

        public byte[] Imagedata { get; set; }
    }
}
