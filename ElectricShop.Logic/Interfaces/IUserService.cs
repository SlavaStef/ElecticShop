using ElectricShop.Common.DTO;
using ElectricShop.Common.Models;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ElectricShop.Logic.Interfaces
{
    public interface IUserService : IDisposable
    {
        Task Create(UserDTO userDTO);
        AppUserManager CreateAppUserManager(IdentityFactoryOptions<AppUserManager> options, IOwinContext context);
        Task<ClaimsIdentity> Authenticate(UserDTO userDTO);
        Task SetInitialData(UserDTO adminDTO, List<string> roles);
    }
}
