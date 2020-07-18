using ElectricShop.Data.Interfaces;
using ElectricShop.Data.Models;
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

        public ViewResult Index() => View(repository.Products);

        public ViewResult Edit(int productId)
        {
            Product product = repository.Products.FirstOrDefault(p => p.Id == productId);
            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                repository.SaveProduct(product);
                TempData["message"] = string.Format($"{product.Name} has been saved");
                return RedirectToAction("Index");
            }
            else
                return View(product);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            repository.SaveProduct(product);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Delete(int productId)
        {
            repository.DeleteProduct(productId);

            return RedirectToAction("Index");
        }
    }
}