﻿using ElectricShop.Infrastructure.Models;

namespace ElectricShop.Data.Repositories
{
    public class ProductCategoryRepository : Repository<ProductCategory>
    {
        public ProductCategoryRepository(ApplicationContext context) : base(context) { }
    }
}