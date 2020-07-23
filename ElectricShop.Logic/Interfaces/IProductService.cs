using ElectricShop.Common.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ElectricShop.Logic.Interfaces
{
    public interface IProductService
    {
        Task AddProductAsync(ProductDTO product);
        Task<ProductDTO> GetProductAsync(int id);
        Task<IEnumerable<ProductDTO>> GetAllProductsAsync();
        Task EditProductAsync(ProductDTO product);
        Task RemoveProductAsync(ProductDTO product);
        Task RemoveProductAsync(int id);
        Task<IEnumerable<ProductDTO>> FindProductsAsync(string searchString);
        void Dispose();
    }
}
