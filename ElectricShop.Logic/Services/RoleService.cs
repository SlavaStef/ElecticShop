using ElectricShop.Common.Models;
using ElectricShop.Data.Context;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace ElectricShop.Logic.Services
{
    public class RoleService
    {


        public AppRoleManager CreateAppRoleManager(IdentityFactoryOptions<AppRoleManager> options, IOwinContext context) => 
            new AppRoleManager(new RoleStore<AppRole>(new ApplicationContext()));
    }
}
