using ElectricShop.Data.Abstract;
using ElectricShop.Data.Entities;
using Moq;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElectricShop.Web.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            Mock<IProductRepository> mock = new Mock<IProductRepository> ();
            mock.Setup(m => m.Products).Returns(new List<Product>
            {
                new Product { Name = "TV", Price = 100 },
                new Product { Name = "Smart speaker", Price = 75 }
            });

            kernel.Bind<IProductRepository>().ToConstant(mock.Object);
        }
    }
}