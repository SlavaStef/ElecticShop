using ElectricShop.Data.Repositories;
using System.Threading.Tasks;

namespace ElectricShop.Data.Interfaces
{
    public interface IUnitOfWork
    {
        ProductBrandRepository ProductBrands { get; }
        ProductCategoryRepository ProductCategories { get; }
        ProductRepository Products { get; }
        ProductSubCategoryRepository ProductSubCategories { get; }

        void DisableAutoDetectChanges();
        Task<int> CompleteAsync();
    }
}
