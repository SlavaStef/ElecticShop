using System.Collections.Generic;

namespace ElectricShop.Common.Models
{
    public class ProductSubCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? CategoryId { get; set; }
        public virtual ProductCategory Category { get; set; }
        public virtual List<Product> Products { get; set; }
    }
}