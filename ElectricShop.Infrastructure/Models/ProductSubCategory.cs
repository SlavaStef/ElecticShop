using System.Collections.Generic;

namespace ElectricShop.Infrastructure.Models
{
    public class ProductSubCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Product> Products { get; set; }
    }
}