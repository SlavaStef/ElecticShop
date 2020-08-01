using AutoMapper;
using ElectricShop.Common.Models;
using ElectricShop.Common.ViewModels;

namespace ElectricShop.Logic.AutoMapper
{
    public class RegisterViewModelToUserProfile : Profile
    {
        public RegisterViewModelToUserProfile()
        {
            CreateMap<RegisterViewModel, AppUser>();
        }
    }
}
