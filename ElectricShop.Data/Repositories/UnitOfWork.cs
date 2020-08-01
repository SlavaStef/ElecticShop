using ElectricShop.Common.Models;
using ElectricShop.Data.Context;
using ElectricShop.Data.Interfaces;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Threading.Tasks;

namespace ElectricShop.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApplicationContext _context;

        private bool disposed = false;

        public UnitOfWork(ApplicationContext context)
        {
            _context = context;

            ProductBrands = new ProductBrandRepository(_context);
            ProductCategories = new ProductCategoryRepository(_context);
            Products = new ProductRepository(_context);
            UserManager = new AppUserManager(new UserStore<AppUser>(_context));
            RoleManager = new AppRoleManager(new RoleStore<AppRole>(_context));

        }

        public ProductBrandRepository ProductBrands { get; private set; }
        public ProductCategoryRepository ProductCategories { get; private set; }
        public ProductRepository Products { get; private set; }
        public AppUserManager UserManager { get; private set; }
        public AppRoleManager RoleManager { get; private set; }


        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void DisableAutoDetectChanges()
        {
            _context.Configuration.AutoDetectChangesEnabled = false;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;
            else
                Dispose();
        }
    }
}
