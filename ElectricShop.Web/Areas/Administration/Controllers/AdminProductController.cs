using ElectricShop.Common.DTO;
using ElectricShop.Logic.Interfaces;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ElectricShop.Web.Areas.Administration.Controllers
{
    public class AdminProductController : Controller
    {
        public IProductService _service { get; set; }

        public AdminProductController(IProductService service)
        {
            _service = service;
        }


        public ActionResult Index()
        {
            //IEnumerable<ProductDTO> products = _service.GetAllProducts();
            //return View(products);
            return null;
        }

        public ActionResult Edit(int productId)
        {
            return View(_service.GetProduct(productId));
        }

        [HttpPost]
        public ActionResult Edit(ProductDTO product)
        {
            if (ModelState.IsValid)
            {
                _service.EditProduct(product);

                return RedirectToAction("Index");
            }
            else
                return View(product);
        }
    }
}