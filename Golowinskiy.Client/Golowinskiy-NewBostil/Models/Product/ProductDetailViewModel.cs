﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Golowinskiy_NewBostil.Models.Product
{
    public class ProductDetailViewModel
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string ProductName { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public string VideoLink { get; set; }

        public string ProductType { get; set; }

        public string ProductArticle { get; set; }

        public string TransformationMechanism { get; set; }

        public string MainImageLink { get; set; }

        public List<string> AdditionalImagesLinks { get; set; }

        public bool IsChange { get; set; }

        public string Position { get; set; }
    }
}
