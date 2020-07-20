using ElectricShop.Common.Models;
using System.Data.Entity;

namespace ElectricShop.Data.Context
{
    public class ApplicationDbInitializer : DropCreateDatabaseIfModelChanges<ApplicationContext>
    {
        protected override void Seed(ApplicationContext context)
        {
            context.Products.Add(new Product { Name = "55UM7300PLB", Description = " 55 3840x2160(4K UHD), матрица IPS, частота матрицы 50 Гц, Smart TV(LG webOS), HDR, Wi - Fi", Price = 1233.72M });
            context.SaveChanges();
        }
    }
}
