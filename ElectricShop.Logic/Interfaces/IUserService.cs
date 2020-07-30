using ElectricShop.Common.DTO;
using ElectricShop.Common.Models;
using ElectricShop.Common.ViewModels;
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
        Task<UserDTO> GetUser(string id);
        Task<IdentityResult> CreateUser(AppUser user, string password);
        Task<IdentityResult> DeleteUser(string Id);
        Task<IdentityResult> EditUser(UserDTO user);
        Task<ClaimsIdentity> Authenticate(LoginViewModel model);
        Task<IdentityResult> AddToRole(string userId, string roleName);
        Task<IdentityResult> RemoveFromRole(string userId, string roleName);

        AppUserManager CreateAppUserManager(IdentityFactoryOptions<AppUserManager> options, IOwinContext context);
    }
}
