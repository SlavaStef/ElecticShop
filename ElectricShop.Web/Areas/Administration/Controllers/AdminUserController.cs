using ElectricShop.Common.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ElectricShop.Web.Areas.Administration.Controllers
{
    public class AdminUserController : Controller
    {
        public ActionResult Index()
        {
            return View(UserManager.Users);
        }

        public ActionResult Create() => View();

        [HttpPost]
        public async Task<ActionResult> Create(CreateUserModel model)
        {
            if(ModelState.IsValid)
            {
                AppUser user = new AppUser { UserName = model.Name, Email = model.Email };
                IdentityResult result = await UserManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                    return RedirectToAction("Index");
            }
            return View(model);
        }



        private AppUserManager UserManager { get { return HttpContext.GetOwinContext().GetUserManager<AppUserManager>(); } } 
    }
}