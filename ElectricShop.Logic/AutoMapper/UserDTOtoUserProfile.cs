using AutoMapper;
using ElectricShop.Common.DTO;
using ElectricShop.Common.Models;

namespace ElectricShop.Logic.AutoMapper
{
    public class UserDTOtoUserMapperProfile : Profile
    {
        public UserDTOtoUserMapperProfile()
        {
            CreateMap<UserDTO, AppUser>();
        }
    }
}
