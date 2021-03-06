﻿using ElectricShop.Common.Models;
using ElectricShop.Logic.Interfaces;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ElectricShop.Web.Areas.Administration.Controllers
{
    [Authorize]
    public class AdminUserController : Controller
    {
        IUserService userService { get; set; }


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
            AppUser user = await userService.GetUser(id);

            if (user != null)
                return View(user);
            else
                return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<ActionResult> Edit(string id, string email, string password)
        {
            IdentityResult editResult = await userService.EditUser(id, email, password);

            if(editResult.Succeeded)
                return RedirectToAction("Index");
                    
            return View(await userService.GetUser(id));
        }
    }
}