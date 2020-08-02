using ElectricShop.Common.DTO;
using ElectricShop.Common.Models;
using ElectricShop.Common.ViewModels;
using ElectricShop.Logic.Interfaces;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ElectricShop.Web.Controllers
{
    public class CartController : Controller
    {
        public IProductService productService { get; set; }

        public CartController(IProductService service)
        {
            productService = service;
        }


        public ViewResult Index(string returnUrl) => View(new CartIndexViewModel { Cart = GetCart(), ReturnUrl = returnUrl });

        public async Task<RedirectToRouteResult> AddToCart(int productId, string returnUrl)
        {
            ProductDTO product = await productService.GetProduct(productId);

            if (product != null)
                GetCart().AddItem(product, 1);

            return RedirectToAction("Index", new { returnUrl });
        }

        public async Task<RedirectToRouteResult> RemoveFromCart(int productId, string returnUrl)
        {
            ProductDTO product = await productService.GetProduct(productId);

            if (product != null)
                GetCart().RemoveLine(product);

            return RedirectToAction("Index", new { returnUrl });
        }

        public PartialViewResult Summary() => PartialView(GetCart());

        private Cart GetCart()
        {
            Cart cart = (Cart)Session["Cart"];

            if (cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }

            return cart;
        }
    }
}