using ElectricShop.Common.Models;
using ElectricShop.Data.Context;

namespace ElectricShop.Data.Repositories
{
    public class ProductSubCategoryRepository : Repository<ProductSubCategory>
    {
        public ProductSubCategoryRepository(ApplicationContext context) : base(context) { }
    }
}
