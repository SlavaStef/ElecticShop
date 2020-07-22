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
            return View();
        }
        public ActionResult ShowAllProducts()
        {
            return View(_service.GetAllProducts());
        }
    }
}