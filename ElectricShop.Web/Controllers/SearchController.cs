using ElectricShop.Common.DTO;
using ElectricShop.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ElectricShop.Web.Controllers
{
    public class SearchController : Controller
    {
        public IProductService service { get; set; }

        public SearchController(IProductService service)
        {
            this.service = service;
        }
   
        [HttpGet]
        public async Task<ActionResult> Search(string searchString)
        {
            IEnumerable<ProductDTO> result = null;

            if (!String.IsNullOrEmpty(searchString))
            {
                result = await service.FindProductsAsync(searchString);
            }

            return View(result);
        }
    }
}