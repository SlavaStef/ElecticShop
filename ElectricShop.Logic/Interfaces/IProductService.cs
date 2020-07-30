using ElectricShop.Common.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ElectricShop.Logic.Interfaces
{
    public interface IProductService : IDisposable
    {
        Task AddProduct(ProductDTO product);
        Task<ProductDTO> GetProduct(int id);
        Task<IEnumerable<ProductDTO>> GetProducts();
        Task EditProduct(ProductDTO product);
        Task RemoveProduct(ProductDTO product);
        Task RemoveProduct(int id);
        Task<IEnumerable<ProductDTO>> FindProducts(string searchString);
    }
}
