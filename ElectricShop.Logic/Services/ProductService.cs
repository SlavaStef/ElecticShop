using AutoMapper;
using ElectricShop.Common.DTO;
using ElectricShop.Common.Models;
using ElectricShop.Data.Interfaces;
using ElectricShop.Logic.Interfaces;
using System.Collections.Generic;

namespace ElectricShop.Logic.Services
{
    public class ProductService : IProductService
    {
        IUnitOfWork _context { get; set; }

        public ProductService(IUnitOfWork context)
        {
            _context = context;
        }

        public ProductDTO GetProduct(int id)
        {            
            Product product = _context.Products.GetAsync(id).Result;
            
            return new ProductDTO { 
                Id = product.Id, 
                Brand = product.Brand, 
                Category = product.Category, 
                SubCategory = product.SubCategory, 
                Description = product.Description, 
                Name = product.Name, 
                Price = product.Price };
        }

        public IEnumerable<ProductDTO> GetAllProducts()
        {
            IMapper mapper = new MapperConfiguration(cfg => cfg.CreateMap<Product, ProductDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Product>, List<ProductDTO>>(_context.Products.GetAllAsync().Result);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
