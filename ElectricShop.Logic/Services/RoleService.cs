using ElectricShop.Common.Models;
using ElectricShop.Data.Context;
using ElectricShop.Logic.Interfaces;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ElectricShop.Logic.Services
{
    public class RoleService : IRoleService
    {
        public IEnumerable<AppRole> Roles { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public AppRoleManager CreateAppRoleManager(IdentityFactoryOptions<AppRoleManager> options, IOwinContext context) => 
            new AppRoleManager(new RoleStore<AppRole>(new ApplicationContext()));

        public Task CreateRoleAsync(AppRole role)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteRoleAsync(AppRole role)
        {
            throw new System.NotImplementedException();
        }

        public Task<AppRole> FindRoleByIdAsync(string id)
        {
            throw new System.NotImplementedException();
        }

        public Task<AppRole> FindRoleByNameAsync(string name)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> RoleExistsAsync(string name)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateRoleAsync(AppRole role)
        {
            throw new System.NotImplementedException();
        }
    }
}
