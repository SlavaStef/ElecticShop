using ElectricShop.Common.Models;
using ElectricShop.Data.Interfaces;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.InteropServices;

namespace ElectricShop.Data.Context
{
    public class ApplicationDbInitializer : DropCreateDatabaseIfModelChanges<ApplicationContext>
    {
        protected override void Seed(ApplicationContext context)
        {
            RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            UserManager<AppUser> userManager = new UserManager<AppUser>(new UserStore<AppUser>(context));

            List<ProductBrand> brands = new List<ProductBrand>
            {
                new ProductBrand { Name = "LG" },
                new ProductBrand { Name = "Samsung" },
                new ProductBrand { Name = "Xiaomi" },
                new ProductBrand { Name = "Apple" },
                new ProductBrand { Name = "Lenovo" },
                new ProductBrand { Name = "Huawei" },
                new ProductBrand { Name = "Sony" },
                new ProductBrand { Name = "Horizont" }
            };
            List<ProductCategory> categories = new List<ProductCategory>
            {
                new ProductCategory { Name = "TV" },
                new ProductCategory { Name = "Mobile" },
                new ProductCategory { Name = "Headphones" },
                new ProductCategory { Name = "Smartwatches" },
                new ProductCategory { Name = "Tablets" }
            };
            context.ProductBrands.AddRange(brands);
            context.ProductCategories.AddRange(categories);
            context.SaveChanges();

            List<Product> products = new List<Product>
            {
                new Product { Name = "Apple iPad 10.2\" 32GB MW742", Description = "Description", Price = 899M, BrandId = 4, CategoryId = 5 },
                new Product { Name = "Lenovo M10 FHD Plus TB-X606X 64GB LTE ZA5V0083UA", Description = "Description", Price = 665M, BrandId = 5, CategoryId = 5 },
                new Product { Name = "Samsung Galaxy Tab A10.1 (2019) LTE 2GB/32GB", Description = "Description", Price = 610M, BrandId = 2, CategoryId = 5 },
                new Product { Name = "Xiaomi Mi Pad 4 64GB", Description = "Description", Price = 720M, BrandId = 3, CategoryId = 5 },
                new Product { Name = "Huawei MatePad 10.4\" BAH3 - L09 64GB LTE", Description = "Description", Price = 849M, BrandId = 6, CategoryId = 5 },
                new Product { Name = "Xiaomi MI TV 4S 43\"", Description = "Description", Price = 8133.12M, BrandId = 3, CategoryId = 1 },
                new Product { Name = "LG 32LM570BPLA", Description = "Description", Price = 498.3M, BrandId = 1, CategoryId = 1 },
                new Product { Name = "Samsung UE32T5300AU", Description = "Description", Price = 617M, BrandId = 2, CategoryId = 1 },
                new Product { Name = "Sony KD-55XG9505", Description = "Description", Price = 2927.94M, BrandId = 7, CategoryId = 1 },
                new Product { Name = "Horizont 32LE5511D", Description = "Description", Price = 295.32M, BrandId = 8, CategoryId = 1 }
            };
            context.Products.AddRange(products);
            context.SaveChanges();

            var adminRole = new IdentityRole { Name = "Admin" };
            var userRole = new IdentityRole { Name = "User" };
            AppUser admin = new AppUser
            {
                Email = "admin.electricshop@mail.com",
                UserName = "Admin",
                FirstName = "Vasya",
                LastName = "Pupkin",
                City = "Minsk",
                Address = "Lenina str., 0-0",
                PhoneNumber = "+000(00)000-00-00"
            };
            AppUser user = new AppUser
            {
                Email = "user.electricshop@mail.com",
                UserName = "User",
                FirstName = "Ivan",
                LastName = "Petrov",
                City = "Moscow",
                Address = "Lenina str., 1-1",
                PhoneNumber = "+111(11)111-11-11"
            };

            roleManager.Create(adminRole);
            roleManager.Create(userRole);
            userManager.Create(admin, "qwerty");
            userManager.Create(user, "qwerty");
            userManager.AddToRole(admin.Id, adminRole.Name);
            userManager.AddToRole(user.Id, userRole.Name);
        }
    }
}
