using ElectricShop.Identity.Infrastructure;
using ElectricShop.Identity.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace ElectricShop.Web.Controllers
{
    public class AccountController : Controller
    {
        private IAuthenticationManager AuthManager { get { return HttpContext.GetOwinContext().Authentication; } }
        private AppUserManager UserManager { get { return HttpContext.GetOwinContext().GetUserManager<AppUserManager>(); } }

        public ActionResult Login(string returnUrl)
        {
            if (HttpContext.User.Identity.IsAuthenticated)
                return View("Error", new string[] { "Access Denied" });

            ViewBag.returnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginModel details, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                AppUser user = await UserManager.FindAsync(details.Name, details.Password);
                if (user == null)
                    ModelState.AddModelError("", "Invalid name or password.");
                else
                {
                    ClaimsIdentity ident = await UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
                    AuthManager.SignOut();
                    AuthManager.SignIn(new AuthenticationProperties { IsPersistent = false }, ident);
                    return RedirectToAction("List", "Product");
                }
            }
            ViewBag.returnUrl = returnUrl;
            return View(details);
        }

        public ActionResult Logout()
        {
            AuthManager.SignOut();
            return RedirectToAction("List", "Product");
        }
    }
}