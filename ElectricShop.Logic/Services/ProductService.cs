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
                Description = product.Description, 
                Name = product.Name,
                Price = product.Price };
        }

        public IEnumerable<ProductDTO> GetAllProducts()
        {
            IMapper mapper = new MapperConfiguration(cfg => { cfg.CreateMap<Product, ProductDTO>(); cfg.CreateMap<ProductBrand, ProductBrandDTO>(); }).CreateMapper();
            IEnumerable<ProductDTO> result = mapper.Map< IEnumerable<Product>, IEnumerable <ProductDTO>>(_context.Products.GetAll());
                                    
            return result;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
