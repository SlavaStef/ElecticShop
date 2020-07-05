using ElectricShop.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElectricShop.Web.Controllers
{
    public class SearchController : Controller
    {
        private IProductRepository repository;

        public SearchController(IProductRepository productRepository)
        {
            repository = productRepository;
        }

        public ActionResult Index(string searchString)
        {
            var items = repository.Products;

            if (!String.IsNullOrEmpty(searchString))
            {
                items = items.Where(s => s.Name.Contains(searchString));
            }

            return View(items.ToList());
        }
    }
}