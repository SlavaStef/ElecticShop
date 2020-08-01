using AutoMapper;
using ElectricShop.Logic.MapperProfiles;

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
                x.AddProfile(new RegisterViewModelToUserDTOProfile());
                x.AddProfile(new RegisterViewModelToUserProfile());
            });

            IMapper mapper = config.CreateMapper();

            return mapper;
        }
    }
}
