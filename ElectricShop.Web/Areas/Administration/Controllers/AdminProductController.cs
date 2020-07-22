using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElectricShop.Web.Areas.Administration.Controllers
{
    public class AdminProductController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}