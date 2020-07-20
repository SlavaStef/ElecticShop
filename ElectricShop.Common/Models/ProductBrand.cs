using System.Collections.Generic;

namespace ElectricShop.Common.Models
{
    public class ProductBrand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Product> Products { get; set; }
        public List<ProductCategory> Categories { get; set; }
        public List<ProductSubCategory> SubCategories { get; set; }
    }
}