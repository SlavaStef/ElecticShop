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
            IMapper mapper = new MapperConfiguration(cfg => { cfg.CreateMap<Product, ProductDTO>(); cfg.CreateMap<ProductBrand, ProductBrandDTO>(); }).CreateMapper();
            ProductDTO product = mapper.Map<ProductDTO>(_context.Products.GetAsync(id).Result);

            return product;
        }

        public IEnumerable<ProductDTO> GetAllProducts()
        {
            IMapper mapper = new MapperConfiguration(cfg => { cfg.CreateMap<Product, ProductDTO>(); cfg.CreateMap<ProductBrand, ProductBrandDTO>(); }).CreateMapper();
            IEnumerable<ProductDTO> products = mapper.Map<IEnumerable<Product>, IEnumerable <ProductDTO>>(_context.Products.GetAll());
                                    
            return products;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
