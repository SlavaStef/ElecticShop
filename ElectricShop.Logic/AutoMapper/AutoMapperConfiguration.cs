using AutoMapper;
using ElectricShop.Logic.MapperProfiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricShop.Logic.AutoMapper
{
    public class AutoMapperConfiguration
    {
        public static IMapper GetMapperConfiguration()
        {
            MapperConfiguration config = new MapperConfiguration(x =>
            {
                x.AddProfile(new UserDTOtoUserMapperProfile());
                x.AddProfile(new UserToUserDTOMapperProfile());
                x.AddProfile(new ProductDTOtoProductProfile());
                x.AddProfile(new ProductToProductDTOProfile());
            });

            IMapper mapper = config.CreateMapper();

            return mapper;
        }
    }
}
