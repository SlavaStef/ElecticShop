using ElectricShop.Common.Models;
using ElectricShop.Data.Context;
using ElectricShop.Data.Interfaces;

namespace ElectricShop.Data.Repositories
{
    public class ProductSubCategoryRepository : Repository<ProductSubCategory>, IProductSubCategoryRepository
    {
        public ProductSubCategoryRepository(ApplicationContext context) : base(context) { }
    }
}
