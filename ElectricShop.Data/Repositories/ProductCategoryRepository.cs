using ElectricShop.Common.Models;
using ElectricShop.Data.Context;

namespace ElectricShop.Data.Repositories
{
    public class ProductCategoryRepository : Repository<ProductCategory>
    {
        public ProductCategoryRepository(ApplicationContext context) : base(context) { }
    }
}
