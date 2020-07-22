using ElectricShop.Common.DTO;
using ElectricShop.Logic.Interfaces;
using ElectricShop.Logic.Services;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ElectricShop.Web.Controllers
{
    public class HomeController : Controller
    {
        public IProductService _service { get; set; }

        public HomeController(IProductService service)
        {
            _service = service;
        }

        public ActionResult Index()
        {
            IEnumerable<ProductDTO> products = _service.GetAllProducts();
            return View(products);
        }
    }
}