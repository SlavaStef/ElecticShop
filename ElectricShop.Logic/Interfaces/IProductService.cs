using ElectricShop.Common.DTO;
using System.Collections.Generic;

namespace ElectricShop.Logic.Interfaces
{
    public interface IProductService
    {
        ProductDTO GetProduct(int id);
        IEnumerable<ProductDTO> GetAllProducts();
        void Dispose();
    }
}
