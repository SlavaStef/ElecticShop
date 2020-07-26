using ElectricShop.Common.DTO;
using ElectricShop.Common.Models;
using ElectricShop.Logic.Interfaces;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ElectricShop.Web.Controllers
{
    public class AccountController : Controller
    {
        IUserService userService;

        public AccountController(IUserService service)
        {
            userService = service;
        }

        private IUserService UserService { get { return HttpContext.GetOwinContext().GetUserManager<IUserService>(); } }
        private IAuthenticationManager AuthenticationManager { get { return HttpContext.GetOwinContext().Authentication; } }
        private AppUserManager UserManager { get { return HttpContext.GetOwinContext().GetUserManager<AppUserManager>(); } }
        private IAuthenticationManager AuthManager { get { return HttpContext.GetOwinContext().Authentication; } }


        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Login(LoginModel model, string returnUrl)
        {            
            if (ModelState.IsValid)
            {
                AppUser user = await UserManager.FindAsync(model.Name, model.Password);

                if (user == null)
                    ModelState.AddModelError("", "Invalid name or password");
                else
                {
                    ClaimsIdentity ident = await UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
                    AuthManager.SignOut();
                    AuthManager.SignIn(new AuthenticationProperties { IsPersistent = false }, ident);
                    return Redirect(returnUrl);
                }
            }
            ViewBag.returnUrl = returnUrl;
            return View(model);
        }

        public ActionResult Logout()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Register() => View();

        [HttpPost]
        public async Task<ActionResult> Register(CreateUserModel model)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser { UserName = model.Name, Email = model.Email };

                IdentityResult result = await userService.CreateUser(user, model.Password);

                if (result.Succeeded)
                    return RedirectToAction("Index", "Home");
            }
            return View(model);
        }

        private async Task SetInitialDataAsync()
        {
            await UserService.SetInitialData(new UserDTO
            {
                Email = "somemail@mail.ru",
                UserName = "somemail@mail.ru",
                Password = "ad46D_ewr3",
                Name = "Семен Семенович Горбунков",
                Address = "ул. Спортивная, д.30, кв.75",
                Role = "admin",
            }, new List<string> { "user", "admin" });
        }
    }
}