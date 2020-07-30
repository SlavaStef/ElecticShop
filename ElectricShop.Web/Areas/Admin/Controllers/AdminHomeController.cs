using System.Web.Mvc;

namespace ElectricShop.Web.Areas.Admin.Controllers
{
    public class AdminHomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}