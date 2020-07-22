using ElectricShop.Common.Models;
using System.Collections.Generic;

namespace ElectricShop.Common.DTO
{
    public class ProductSubCategoryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Product> Products { get; set; }
    }
}
