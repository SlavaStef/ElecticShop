using ElectricShop.Common.Models;
using ElectricShop.Data.Context;
using ElectricShop.Data.Interfaces;

namespace ElectricShop.Data.Repositories
{
    public class ProductBrandRepository : Repository<ProductBrand>, IProductBrandRepository
{
        public ProductBrandRepository(ApplicationContext context) : base(context) { }
    }
}
