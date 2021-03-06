﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Golowinskiy_NewBostil.Models.Product
{
    public class EditProductViewModel : ProductDetailViewModel
    {
        public int CategoryId { get; set; }

        public string UserId { get; set; }

        public string UserName { get; set; }

        public Dictionary<int, string> AdditionalDictImagesLinks { get; set; }

        public IFormFile MainImage { get; set; }

        public List<IFormFile> AdditionalImages { get; set; }
    }
}
