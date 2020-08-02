using ElectricShop.Common.DTO;
using ElectricShop.Logic.Interfaces;
using System.EnterpriseServices;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ElectricShop.Web.Areas.Admin.Controllers
{
    [Authorize (Roles = "Admin")]
    public class ProductController : Controller
    {
        public IProductService service { get; set; }

        public ProductController(IProductService service)
        {
            this.service = service;
        }


        public async Task<ActionResult> Index() => View(await service.GetProducts());

        public ActionResult Create() => View();

        [HttpPost]
        public async Task<ActionResult> Create(ProductDTO product)
        {
            if(ModelState.IsValid)
            {
                await service.AddProduct(product);
                return RedirectToAction("Index");
            }
            return View(product);
        }

        [HttpPost]
        public async Task<ActionResult> Details(int? productId)
        {
            return View(await service.GetProduct((int)productId));
        }

        public async Task<ActionResult> Edit(int? productId)
        {
            if(productId == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            ProductDTO product = await service.GetProduct((int)productId);

            if (product == null)
                return HttpNotFound();

            return View(product);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(ProductDTO product)
        {
            if (ModelState.IsValid)
            {
                await service.EditProduct(product);
                
                return RedirectToAction("Index");
            }
            else
                return View(product);
        }

        [HttpPost]
        public async Task<ActionResult> Delete(int? productId)
        {
            if (productId != null)
                await service.RemoveProduct((int)productId);
            
            return RedirectToAction("Index");
        }
    }
}