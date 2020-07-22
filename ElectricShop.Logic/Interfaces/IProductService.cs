using ElectricShop.Common.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ElectricShop.Logic.Interfaces
{
    public interface IProductService
    {
        ProductDTO GetProduct(int id);
        IEnumerable<ProductDTO> GetAllProducts();
        Task AddProductAsync(ProductDTO product);
        Task RemoveProductAsync(int id);
        void Dispose();
    }
}
