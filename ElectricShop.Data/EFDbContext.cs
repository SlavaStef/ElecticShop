using ElectricShop.Data.Entities;
using System.Data.Entity;

namespace ElectricShop.Data
{
    public class EFDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
    }
}
