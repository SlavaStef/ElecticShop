using ElectricShop.Logic.Interfaces;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ElectricShop.Web.Controllers
{
    public class HomeController : Controller
    {
        public IProductService service { get; set; }

        public HomeController(IProductService service)
        {
            this.service = service;
        }


        public async Task<ActionResult> Index()
        {            
            return View(await service.GetAllProductsAsync());
        }
    }
}