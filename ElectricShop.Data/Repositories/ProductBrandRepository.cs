using ElectricShop.Common.Models;
using ElectricShop.Data.Context;

namespace ElectricShop.Data.Repositories
{
    public class ProductBrandRepository : Repository<ProductBrand>
    {
        public ProductBrandRepository(ApplicationContext context) : base(context) { }
    }
}
