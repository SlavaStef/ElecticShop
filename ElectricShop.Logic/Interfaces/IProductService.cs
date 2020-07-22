using ElectricShop.Common.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ElectricShop.Logic.Interfaces
{
    public interface IProductService
    {
        Task AddProductAsync(ProductDTO product);
        ProductDTO GetProduct(int id);
        IEnumerable<ProductDTO> GetAllProducts();
        void EditProduct(ProductDTO product);
        Task RemoveProductAsync(ProductDTO product);
        Task RemoveProductAsync(int id);
        void Dispose();
    }
}
