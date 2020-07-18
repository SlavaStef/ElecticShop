using ElectricShop.Data.Models;

namespace ElectricShop.Data.Repositories
{
    public class ProductBrandRpository : Repository<ProductBrand>
    {
        public ProductBrandRpository(ApplicationContext context) : base(context) { }
    }
}
