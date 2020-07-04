﻿using ElectricShop.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricShop.Data.Abstract
{
    public interface IProductRepository
    {
        IEnumerable<Product> Products { get; }
    }
}