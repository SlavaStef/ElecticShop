using ElectricShop.Data.Interfaces;
using ElectricShop.Data.Repositories;
using ElectricShop.Logic.Interfaces;
using ElectricShop.Logic.Services;
using Ninject.Modules;

namespace ElectricShop.Logic
{
    public class ServiceModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUnitOfWork>().To<UnitOfWork>();
            Bind<IProductService>().To<ProductService>();
            Bind<IUserService>().To<UserService>();
            Bind<IRoleService>().To<RoleService>();
        }
    }
}
