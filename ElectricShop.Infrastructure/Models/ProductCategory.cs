using System.Collections.Generic;

namespace ElectricShop.Infrastructure.Models
{
    public class ProductCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Product> Products { get; set; }
        public List<ProductSubCategory> SubCategories { get; set; }
    }
}