using ElectricShop.Data.Entities;
using System.Collections.Generic;

namespace ElectricShop.Web.Models
{
    public class ProductsListViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; }
    }
}