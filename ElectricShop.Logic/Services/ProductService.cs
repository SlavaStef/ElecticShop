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
        IUnitOfWork context { get; set; }
        IMapper mapper { get; set; }

        public ProductService(IUnitOfWork context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        
        public async Task<ProductDTO> GetProduct(int id)
        {
            return mapper.Map<ProductDTO>(await context.Products.GetAsync(id));
        }

        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {                                       
            return mapper.Map<IEnumerable<ProductDTO>>(await context.Products.GetAllAsync());
        }

        public async Task AddProduct(ProductDTO product)
        {            
            await context.Products.AddAsync(mapper.Map<Product>(product));
        }

        public async Task EditProduct(ProductDTO product)
        {
            Product _product = await context.Products.GetAsync(product.Id);

            if(_product != null)
                _product = mapper.Map<Product>(product);

            await context.Products.SaveChangesAsync();
        }

        public async Task RemoveProduct(ProductDTO product)
        {
            await context.Products.RemoveAsync(mapper.Map<Product>(product));
        }

        public async Task RemoveProduct(int id)
        {
            await context.Products.RemoveAsync(id);
        }

        public async Task<IEnumerable<ProductDTO>> FindProducts(string searchString)
        {
            IEnumerable<Product> searchResult = await context.Products.FindAsync(product => 
                product.Name.Contains(searchString) | 
                product.Brand.Name.Contains(searchString) | 
                product.Description.Contains(searchString));
                        
            return mapper.Map<IEnumerable<ProductDTO>>(searchResult);
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}