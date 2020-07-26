using ElectricShop.Common.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ElectricShop.Logic.Interfaces
{
    public interface IRoleService
    {
        Task<IEnumerable<AppRole>> GetRoles();
        Task<AppRole> GetRole(string id);
        Task<IdentityResult> CreateRole(string name);
        Task<IdentityResult> DeleteRole(string id);
        

        AppRoleManager CreateAppRoleManager(IdentityFactoryOptions<AppRoleManager> options, IOwinContext context);
    }
}