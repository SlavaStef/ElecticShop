using ElectricShop.Common.Models;
using System.Data.Entity;

namespace ElectricShop.Data.Context
{
    public class ApplicationContext : DbContext
    {
        static ApplicationContext()
        {
            Database.SetInitializer<ApplicationContext>(new ApplicationDbInitializer());
        }
        public ApplicationContext(string connectionString) : base(connectionString) { }
        
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductBrand> ProductBrands { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductSubCategory> ProductSubCategories { get; set; }
    }
}