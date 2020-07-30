﻿using ElectricShop.Common.Models;
using ElectricShop.Common.ViewModels;
using ElectricShop.Logic.Interfaces;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ElectricShop.Web.Controllers
{
    public class AccountController : Controller
    {
        IUserService userService;
        private IAuthenticationManager AuthManager { get { return HttpContext.GetOwinContext().Authentication; } }

        public AccountController(IUserService service)
        {
            userService = service;
        }


        public ActionResult Register() => View();

        [HttpPost]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser 
                { 
                    UserName = model.Name, 
                    Email = model.Email, 
                    FirstName = model.FirstName, 
                    LastName = model.LastName, 
                    City = model.City, 
                    Address = model.Address, 
                    PhoneNumber = model.PhoneNumber 
                };

                IdentityResult result = await userService.CreateUser(user, model.Password);

                if (result.Succeeded)
                    return RedirectToAction("Index", "Home");
            }
            return View(model);
        }

        public ActionResult Login(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if(ModelState.IsValid)
            {
                ClaimsIdentity claim = await userService.Authenticate(model);

                if (claim != null)
                {
                    AuthManager.SignOut();
                    AuthManager.SignIn(new AuthenticationProperties { IsPersistent = false }, claim);

                    return Redirect(returnUrl);
                }
            }

            ViewBag.returnUrl = returnUrl;
            return View(model);
        }

        public ActionResult Logout()
        {
            AuthManager.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}