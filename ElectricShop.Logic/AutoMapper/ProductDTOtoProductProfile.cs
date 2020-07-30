using AutoMapper;
using ElectricShop.Common.DTO;
using ElectricShop.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricShop.Logic.AutoMapper
{
    public class ProductDTOtoProductProfile : Profile
    {
        public ProductDTOtoProductProfile()
        {
            CreateMap<ProductDTO, Product>();
                //.ForMember(x => x.Brand.Name, opt => opt.MapFrom(source => source.BrandName))
                //.ForMember(x => x.Category.Name, opt => opt.MapFrom(source => source.CategoryName))
                //.ForMember(x => x.SubCategory.Name, opt => opt.MapFrom(source => source.SubCategoryName));
        }
    }
}
