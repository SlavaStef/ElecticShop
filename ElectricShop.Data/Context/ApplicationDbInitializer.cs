using ElectricShop.Common.Models;
using System.Data.Entity;

namespace ElectricShop.Data.Context
{
    public class ApplicationDbInitializer : DropCreateDatabaseIfModelChanges<ApplicationContext>
    {
        protected override void Seed(ApplicationContext context)
        {
            context.ProductBrands.Add(new ProductBrand { Name = "LG" });
            context.ProductBrands.Add(new ProductBrand { Name = "Samsung" });
            context.ProductBrands.Add(new ProductBrand { Name = "Xiaomi" });
            context.ProductBrands.Add(new ProductBrand { Name = "Apple" });
            context.ProductBrands.Add(new ProductBrand { Name = "Lenovo" });
            context.ProductBrands.Add(new ProductBrand { Name = "Huawei" });
            context.ProductBrands.Add(new ProductBrand { Name = "Sony" });
            context.ProductBrands.Add(new ProductBrand { Name = "Horizont" });

            context.ProductCategories.Add(new ProductCategory { Name = "Electronics" });
            context.ProductCategories.Add(new ProductCategory { Name = "Computers" });

            context.ProductSubCategories.Add(new ProductSubCategory { Name = "TV", CategoryId = 1});
            context.ProductSubCategories.Add(new ProductSubCategory { Name = "Mobile", CategoryId = 1 });
            context.ProductSubCategories.Add(new ProductSubCategory { Name = "Headphones", CategoryId = 1 });
            context.ProductSubCategories.Add(new ProductSubCategory { Name = "Smartwatches", CategoryId = 1 });
            context.ProductSubCategories.Add(new ProductSubCategory { Name = "Tablets", CategoryId = 1 });

            context.Products.Add(new Product { Name = "Apple iPad 10.2\" 32GB MW742", Description = "Description", Price = 899M });
            context.Products.Add(new Product { Name = "Lenovo M10 FHD Plus TB-X606X 64GB LTE ZA5V0083UA", Description = "Description", Price = 665M });
            context.Products.Add(new Product { Name = "Samsung Galaxy Tab A10.1 (2019) LTE 2GB/32GB", Description = "Description", Price = 610M });
            context.Products.Add(new Product { Name = "Xiaomi Mi Pad 4 64GB", Description = "Description", Price = 720M });
            context.Products.Add(new Product { Name = "Huawei MatePad 10.4\" BAH3 - L09 64GB LTE", Description = "Description", Price = 849M });
            context.Products.Add(new Product { Name = "Xiaomi MI TV 4S 43\"", Description = "Description", Price = 8133.12M });
            context.Products.Add(new Product { Name = "LG 32LM570BPLA", Description = "Description", Price = 498.3M });
            context.Products.Add(new Product { Name = "Samsung UE32T5300AU", Description = "Description", Price = 617M });
            context.Products.Add(new Product { Name = "Sony KD-55XG9505", Description = "Description", Price = 2927.94M });
            context.Products.Add(new Product { Name = "Horizont 32LE5511D", Description = "Description", Price = 295.32M });

            context.SaveChanges();
        }
    }
}
