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
                cfg.CreateMap<ProductCategoryDTO, ProductCategory>();
                cfg.CreateMap<ProductSubCategoryDTO, ProductSubCategory>();
            }).CreateMapper();

            await _context.Products.AddAsync(mapper.Map<Product>(product));
        }

        public async Task<ProductDTO> GetProductAsync(int id)
        {
            IMapper mapper = new MapperConfiguration(cfg => { 
                cfg.CreateMap<Product, ProductDTO>(); 
                cfg.CreateMap<ProductBrand, ProductBrandDTO>();
                cfg.CreateMap<ProductCategory, ProductCategoryDTO>();
                cfg.CreateMap<ProductSubCategory, ProductSubCategoryDTO>();
            }).CreateMapper();

            return mapper.Map<ProductDTO>(await _context.Products.GetAsync(id));
        }

        public async Task<IEnumerable<ProductDTO>> GetAllProductsAsync()
        {
            IMapper mapper = new MapperConfiguration(cfg => {
                cfg.CreateMap<Product, ProductDTO>();
                cfg.CreateMap<ProductBrand, ProductBrandDTO>();
                cfg.CreateMap<ProductCategory, ProductCategoryDTO>();
                cfg.CreateMap<ProductSubCategory, ProductSubCategoryDTO>();
            }).CreateMapper();
                                                
            return mapper.Map<IEnumerable<ProductDTO>>(await _context.Products.GetAllAsync());
        }

        public async Task EditProductAsync(ProductDTO product)
        {
            Product _product = await _context.Products.GetAsync(product.Id);

            if(_product != null)
            {
                IMapper mapper = new MapperConfiguration(cfg => {
                    cfg.CreateMap<ProductDTO, Product>();
                    cfg.CreateMap<ProductBrandDTO, ProductBrand>();
                    cfg.CreateMap<ProductCategoryDTO, ProductCategory>();
                    cfg.CreateMap<ProductSubCategoryDTO, ProductSubCategory>();
                }).CreateMapper();

                _product = mapper.Map<Product>(product);
            }

            await _context.Products.SaveChangesAsync();
        }

        public async Task RemoveProductAsync(ProductDTO product)
        {
            IMapper mapper = new MapperConfiguration(cfg => {
                cfg.CreateMap<ProductDTO, Product>();
                cfg.CreateMap<ProductBrandDTO, ProductBrand>();
                cfg.CreateMap<ProductCategoryDTO, ProductCategory>();
                cfg.CreateMap<ProductSubCategoryDTO, ProductSubCategory>();
            }).CreateMapper();

            await _context.Products.RemoveAsync(mapper.Map<Product>(product));
        }

        public async Task RemoveProductAsync(int id)
        {
            await _context.Products.RemoveAsync(id);
        }

        public async Task<IEnumerable<ProductDTO>> FindProductsAsync(string searchString)
        {
            IEnumerable<Product> searchResult = await _context.Products.FindAsync(product => 
                product.Name.Contains(searchString) | 
                product.Brand.Name.Contains(searchString) | 
                product.Description.Contains(searchString));

            IMapper mapper = new MapperConfiguration(cfg => {
                cfg.CreateMap<Product, ProductDTO>();
                cfg.CreateMap<ProductBrand, ProductBrandDTO>();
                cfg.CreateMap<ProductCategory, ProductCategoryDTO>();
                cfg.CreateMap<ProductSubCategory, ProductSubCategoryDTO>();
            }).CreateMapper();

            return mapper.Map<IEnumerable<ProductDTO>>(searchResult);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}