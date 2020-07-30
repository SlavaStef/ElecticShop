using AutoMapper;
using ElectricShop.Common.DTO;
using ElectricShop.Common.Models;

namespace ElectricShop.Logic.MapperProfiles
{
    public class UserToUserDTOMapperProfile : Profile
    {
        public UserToUserDTOMapperProfile()
        {
            CreateMap<AppUser, UserDTO>();
        }
    }

    public class UserDTOtoUserMapperProfile : Profile
    {
        public UserDTOtoUserMapperProfile()
        {
            CreateMap<UserDTO, AppUser>();
        }
    }
}