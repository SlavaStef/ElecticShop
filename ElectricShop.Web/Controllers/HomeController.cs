using ElectricShop.Common.DTO;
using ElectricShop.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ElectricShop.Web.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        public IProductService service { get; set; }

        public HomeController(IProductService service)
        {
            this.service = service;
        }


        public async Task<ActionResult> Index()
        {            
            return View(await service.GetProducts());
        }

        [HttpGet]
        public async Task<ActionResult> Search(string searchString)
        {
            IEnumerable<ProductDTO> result = null;

            if (!String.IsNullOrEmpty(searchString))
            {
                result = await service.FindProducts(searchString);
            }

            return View(result);
        }
    }
}