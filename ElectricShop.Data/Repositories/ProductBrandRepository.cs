﻿using ElectricShop.Data.Models;

namespace ElectricShop.Data.Repositories
{
    public class ProductBrandRepository : Repository<ProductBrand>
    {
        public ProductBrandRepository(ApplicationContext context) : base(context) { }
    }
}
