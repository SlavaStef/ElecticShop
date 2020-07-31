using ElectricShop.Common.Models;
using ElectricShop.Data.Context;
using ElectricShop.Data.Interfaces;
using ElectricShop.Logic.Interfaces;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace ElectricShop.Logic.Services
{
    public class RoleService : IRoleService
    {
        IUnitOfWork context { get; set; }

        public RoleService(IUnitOfWork context)
        {
            this.context = context;
        }


        public async Task<AppRole> GetRole(string id) => await context.RoleManager.FindByIdAsync(id);

        public async Task<IEnumerable<AppRole>> GetRoles() => await context.RoleManager.Roles.ToListAsync();
                
        public async Task<IdentityResult> CreateRole(string name)
        {
            return await context.RoleManager.CreateAsync(new AppRole(name));
        }

        public async Task<IdentityResult> DeleteRole(string id)
        {
            AppRole role = await context.RoleManager.FindByIdAsync(id);
            IdentityResult deleteResult = null;

            if (role != null)
                deleteResult = await context.RoleManager.DeleteAsync(role);

            return deleteResult;
        }



        public AppRoleManager CreateAppRoleManager(IdentityFactoryOptions<AppRoleManager> options, IOwinContext context) => 
            new AppRoleManager(new RoleStore<AppRole>(new ApplicationContext()));

    }
}
