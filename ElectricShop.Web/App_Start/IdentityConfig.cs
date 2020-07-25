using ElectricShop.Common.Models;
using ElectricShop.Logic;
using ElectricShop.Logic.Interfaces;
using ElectricShop.Logic.Services;
using Microsoft.AspNet.Identity;
using Owin;

namespace ElectricShop.Web.App_Start
{
    public class IdentityConfig
    {
        ServiceCreator serviceCreator = new ServiceCreator();
        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext(CreateUserService);
            app.CreatePerOwinContext<AppUserManager>(CreateUserService().CreateAppUserManager);
            app.UseCookieAuthentication(new Microsoft.Owin.Security.Cookies.CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new Microsoft.Owin.PathString("/Account/Login")
            });   
        }

        private IUserService CreateUserService()
        {
            return serviceCreator.CreateUserService();
        }
    }
}