using ElectricShop.Infrastructure.Models.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace ElectricShop.Data.Context
{
    public class IdentityContext : IdentityDbContext<AppUser>
    {
        public IdentityContext() : base("IdentityDb") { }

        public static IdentityContext Create() => new IdentityContext();
    }

    public class IdentityDbInit : DropCreateDatabaseIfModelChanges<IdentityContext>
    {
        protected override void Seed(IdentityContext context)
        {
            PerformIntialSetup(context);
            base.Seed(context);
        }

        public void PerformIntialSetup(IdentityContext context)
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
