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
    public class UserDTOtoUserMapperProfile : Profile
    {
        public UserDTOtoUserMapperProfile()
        {
            CreateMap<UserDTO, AppUser>();
        }
    }
}
