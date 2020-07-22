using ElectricShop.Common.DTO;
using ElectricShop.Logic.Interfaces;
using ElectricShop.Logic.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
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
            return null;
        }
        public async Task<ActionResult> ShowAllProducts()
        {            
            return View(await _service.GetAllProducts());
        }
    }
}