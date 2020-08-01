using ElectricShop.Common.Models;
using ElectricShop.Data.Repositories;
using System.Threading.Tasks;

namespace ElectricShop.Data.Interfaces
{
    public interface IUnitOfWork
    {
        ProductBrandRepository ProductBrands { get; }
        ProductCategoryRepository ProductCategories { get; }
        ProductRepository Products { get; }

        AppUserManager UserManager { get; }
        AppRoleManager RoleManager { get; }

        void DisableAutoDetectChanges();
        Task<int> CompleteAsync();

        void Dispose();
    }
}
