using ElectricShop.Identity.Models;
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

        }
    }
}
