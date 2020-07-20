using ElectricShop.Data.Interfaces;
using Ninject.Modules;

namespace ElectricShop.Logic
{
    public class ServiceModule : NinjectModule
    {
        private string connectionString;

        public ServiceModule(string connection)
        {
            connectionString = connection;
        }

        public override void Load()
        {
            Bind<IUnitOfWork>().To<IUnitOfWork>().WithConstructorArgument(connectionString);
        }
    }
}
