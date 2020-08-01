using AutoMapper;
using ElectricShop.Common.DTO;
using ElectricShop.Common.ViewModels;

namespace ElectricShop.Logic.AutoMapper
{
    public class RegisterViewModelToUserDTOProfile : Profile
    {
        public RegisterViewModelToUserDTOProfile()
        {
            CreateMap<RegisterViewModel, UserDTO>()
                .ForMember(dest => dest.Id, source => source.Ignore());
        }
    }
}
