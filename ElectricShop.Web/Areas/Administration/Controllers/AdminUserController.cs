using ElectricShop.Common.Models;
using ElectricShop.Logic.Interfaces;
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
        IUserService userService;

        public AdminUserController(IUserService service)
        {
            userService = service;
        }


        public async Task<ActionResult> Index() => View(await userService.GetUsers());

        public ActionResult Create() => View();

        [HttpPost]
        public async Task<ActionResult> Create(CreateUserModel model)
        {
            if(ModelState.IsValid)
            {
                AppUser user = new AppUser { UserName = model.Name, Email = model.Email };

                IdentityResult result = await userService.CreateUser(user, model.Password);

                if (result.Succeeded)
                    return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Delete(string id)
        {
            if (await userService.DeleteUser(id) == IdentityResult.Success)
                return RedirectToAction("Index");
            else
                return View("Error", new string[] { "User not found" });
        }

        public async Task<ActionResult> Edit(string id)
        {
            AppUser user = await UserManager.FindByIdAsync(id);

            if (user != null)
                return View(user);
            else
                return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<ActionResult> Edit(string id, string email, string password)
        {
            AppUser user = await UserManager.FindByIdAsync(id);

            if (user != null)
            {
                user.Email = email;
                IdentityResult validEmail = await UserManager.UserValidator.ValidateAsync(user);

                IdentityResult validPass = null;
                if (password != string.Empty)
                {
                    validPass = await UserManager.PasswordValidator.ValidateAsync(password);
                    if (validPass.Succeeded)
                        user.PasswordHash = UserManager.PasswordHasher.HashPassword(password);
                }

                if ((validEmail.Succeeded && validPass == null) || (validEmail.Succeeded && password != string.Empty && validPass.Succeeded))
                {
                    IdentityResult result = await UserManager.UpdateAsync(user);

                    if (result.Succeeded)
                        return RedirectToAction("Index");
                    else
                        throw new Exception();
                }
            }

            return View(user);
        }


        private AppUserManager UserManager { get { return HttpContext.GetOwinContext().GetUserManager<AppUserManager>(); } } 
    }
}