using ElectricShop.Identity.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace ElectricShop.Identity.Infrastructure
{
    public class AppIdentityDbContext : IdentityDbContext<AppUser>
    {
        public AppIdentityDbContext() : base("IdentityDb") { }

        public static AppIdentityDbContext Create() => new AppIdentityDbContext();
    }

    public class IdentityDbInit : DropCreateDatabaseIfModelChanges<AppIdentityDbContext>
    {
        protected override void Seed(AppIdentityDbContext context)
        {
            PerformIntialSetup(context);
            base.Seed(context);
        }

        public void PerformIntialSetup(AppIdentityDbContext context)
        {
            AppUserManager userMgr = new AppUserManager(new UserStore<AppUser>(context));
            AppRoleManager roleMgr = new AppRoleManager(new RoleStore<AppRole>(context));

            string userName = "Admin";
            string password = "Secret123";
            string email = "admin@example.com";

            if (!roleMgr.RoleExists("Administrators"))
                roleMgr.Create(new AppRole("Administrators"));

            AppUser user = userMgr.FindByName(userName);
            if (user == null)
            {
                userMgr.Create(new AppUser { UserName = userName, Email = email }, password);
                user = userMgr.FindByName(userName);
            }

            if (!userMgr.IsInRole(user.Id, "Administrators"))           
                userMgr.AddToRole(user.Id, "Administrators");
        }
    }
}
