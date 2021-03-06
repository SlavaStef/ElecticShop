﻿using ElectricShop.Common.Models;
using System.Collections.Generic;

namespace ElectricShop.Data.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> Products { get; }

        void SaveProduct(Product product);

        Product DeleteProduct(int productId);
    }
}