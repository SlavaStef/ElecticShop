using ElectricShop.Data.Models;

namespace ElectricShop.Data.Repositories
{
    public class ProductSubCategoryRepository : Repository<ProductSubCategory>
    {
        public ProductSubCategoryRepository(ApplicationContext context) : base(context) { }
    }
}
