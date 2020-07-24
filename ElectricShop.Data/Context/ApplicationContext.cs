using ElectricShop.Common.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace ElectricShop.Data.Context
{
    public class ApplicationContext : IdentityDbContext<AppUser>
    {
        public ApplicationContext() : base("ApplicationDb") { }
        static ApplicationContext() 
        {
            Database.SetInitializer(new ApplicationDbInitializer());
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductBrand> ProductBrands { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductSubCategory> ProductSubCategories { get; set; }

        public static ApplicationContext Create() => new ApplicationContext();
    }
}