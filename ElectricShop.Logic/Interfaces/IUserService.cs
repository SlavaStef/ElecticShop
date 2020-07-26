using ElectricShop.Common.DTO;
using ElectricShop.Common.Models;
using Microsoft.AspNet.Identity;
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
        Task<IEnumerable<AppUser>> GetUsers();
        Task<IdentityResult> CreateUser(AppUser user, string password);
        Task<IdentityResult> DeleteUser(string Id);
        Task<ClaimsIdentity> Authenticate(LoginModel model);


        AppUserManager CreateAppUserManager(IdentityFactoryOptions<AppUserManager> options, IOwinContext context);
    }
}
