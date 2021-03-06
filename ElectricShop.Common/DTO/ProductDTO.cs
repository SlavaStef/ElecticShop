﻿using ElectricShop.Common.Models;

namespace ElectricShop.Common.DTO
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public ProductBrandDTO Brand { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public ProductCategory Category { get; set; }
        public ProductSubCategory SubCategory { get; set; }
    }
}
