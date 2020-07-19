using ElectricShop.Infrastructure.Models;

namespace ElectricShop.Data.Repositories
{
    public class ProductRepository : Repository<Product>
    {
        public ProductRepository(ApplicationContext context) : base(context) { }
    }
}
