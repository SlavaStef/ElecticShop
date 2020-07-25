using ElectricShop.Common.Models;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ElectricShop.Logic.Interfaces
{
    public interface IRoleService
    {
        Task CreateRoleAsync(AppRole role);
        Task DeleteRoleAsync(AppRole role);
        Task<AppRole> FindRoleByIdAsync(string id);
        Task<AppRole> FindRoleByNameAsync(string name);
        Task<bool> RoleExistsAsync(string name);
        Task UpdateRoleAsync(AppRole role);
        IEnumerable<AppRole> Roles { get; set; }
        AppRoleManager CreateAppRoleManager(IdentityFactoryOptions<AppRoleManager> options, IOwinContext context);
    }
}