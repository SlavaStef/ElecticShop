using ElectricShop.Common.Models;
using ElectricShop.Data.Context;

namespace ElectricShop.Data.Repositories
{
    public class ProductRepository : Repository<Product>
    {
        public ProductRepository(ApplicationContext context) : base(context) { }
    }
}
