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
        Task<AppUser> GetUser(string id);
        Task<IdentityResult> CreateUser(AppUser user, string password);
        Task<IdentityResult> DeleteUser(string Id);
        Task<IdentityResult> EditUser(string id, string email, string password);
        Task<ClaimsIdentity> Authenticate(LoginModel model);
        Task<IdentityResult> AddToRole(string userId, string roleName);
        Task<IdentityResult> RemoveFromRole(string userId, string roleName);

        AppUserManager CreateAppUserManager(IdentityFactoryOptions<AppUserManager> options, IOwinContext context);
    }
}
