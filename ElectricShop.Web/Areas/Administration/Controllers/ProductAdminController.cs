using ElectricShop.Data.Abstract;
using ElectricShop.Data.Entities;
using System.Linq;
using System.Web.Mvc;

namespace ElectricShop.Web.Areas.Administration.Controllers
{
    public class ProductAdminController : Controller
    {
        private IProductRepository repository;

        public ProductAdminController(IProductRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index()
        {
            return View(repository.Products);
        }

        public ViewResult Edit(int productId)
        {
            Product product = repository.Products.FirstOrDefault(p => p.ProductID == productId);
            return View(product);
        }
    }
}