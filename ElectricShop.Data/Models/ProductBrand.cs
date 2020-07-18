﻿using System.Collections.Generic;

namespace ElectricShop.Data.Models
{
    public class ProductBrand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Product> Products { get; set; }
        public List<ProductCategory> Categories { get; set; }
        public List<ProductSubCategory> SubCategories { get; set; }
    }
}