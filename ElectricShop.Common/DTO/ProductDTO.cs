using ElectricShop.Common.Models;

namespace ElectricShop.Common.DTO
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public ProductBrand Brand { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
