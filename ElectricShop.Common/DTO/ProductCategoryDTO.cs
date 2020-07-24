using ElectricShop.Common.Models;
using System.Collections.Generic;

namespace ElectricShop.Common.DTO
{
    public class ProductCategoryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Product> Products { get; set; }
        public List<ProductSubCategory> SubCategories { get; set; }
    }
}
