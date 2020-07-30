using ElectricShop.Common.DTO;
using ElectricShop.Common.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricShop.Logic.AutoMapper
{
    public class ProductToProductDTOProfile : Profile
    {
        public ProductToProductDTOProfile()
        {
            CreateMap<Product, ProductDTO>()
                .ForMember(x => x.BrandName, opt => opt.MapFrom(source => source.Brand.Name))
                .ForMember(x => x.CategoryName, opt => opt.MapFrom(source => source.Category.Name))
                .ForMember(x => x.SubCategoryName, opt => opt.MapFrom(source => source.SubCategory.Name));
        }
    }
}
