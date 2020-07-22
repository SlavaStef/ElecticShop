using AutoMapper;
using ElectricShop.Common.DTO;
using ElectricShop.Common.Models;
using ElectricShop.Data.Interfaces;
using ElectricShop.Logic.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ElectricShop.Logic.Services
{
    public class ProductService : IProductService
    {
        IUnitOfWork _context { get; set; }

        public ProductService(IUnitOfWork context)
        {
            _context = context;
        }


        public async Task AddProductAsync(ProductDTO product)
        {
            IMapper mapper = new MapperConfiguration(cfg => {
                cfg.CreateMap<ProductDTO, Product>();
                cfg.CreateMap<ProductBrandDTO, ProductBrand>();
            }).CreateMapper();

            Product _product = mapper.Map<Product>(product);
            await _context.Products.AddAsync(_product);
        }

        public ProductDTO GetProduct(int id)
        {
            IMapper mapper = new MapperConfiguration(cfg => { cfg.CreateMap<Product, ProductDTO>(); cfg.CreateMap<ProductBrand, ProductBrandDTO>(); }).CreateMapper();
            ProductDTO product = mapper.Map<ProductDTO>(_context.Products.GetAsync(id).Result);

            return product;
        }

        public IEnumerable<ProductDTO> GetAllProducts()
        {
            IMapper mapper = new MapperConfiguration(cfg => { 
                cfg.CreateMap<Product, ProductDTO>(); 
                cfg.CreateMap<ProductBrand, ProductBrandDTO>(); 
            }).CreateMapper();
            
            IEnumerable<ProductDTO> products = mapper.Map<IEnumerable<Product>, IEnumerable <ProductDTO>>(_context.Products.GetAllAsync().Result);
                                    
            return products;
        }

        public void EditProduct(ProductDTO product)
        {
            RemoveProductAsync(product.Id);
            AddProductAsync(product);
        }

        public async Task RemoveProductAsync(ProductDTO product)
        {
            IMapper mapper = new MapperConfiguration(cfg => { 
                cfg.CreateMap<ProductDTO, Product>(); 
                cfg.CreateMap<ProductBrandDTO, ProductBrand>(); 
            }).CreateMapper();

            Product _product = mapper.Map<Product>(product);

            await _context.Products.RemoveAsync(_product);
        }

        public async Task RemoveProductAsync(int id)
        {
            await _context.Products.RemoveAsync(id);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
