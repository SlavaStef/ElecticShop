﻿using ElectricShop.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElectricShop.Web.Models
{
    public class CartIndexViewModel
    {
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }
    }
}