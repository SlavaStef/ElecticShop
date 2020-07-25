using ElectricShop.Common.Models;
using ElectricShop.Logic.Interfaces;
using ElectricShop.Logic.Services;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ElectricShop.Web.Areas.Administration.Controllers
{
    public class AdminRoleController : Controller
    {
        IRoleService roleService { get; set; }

        public AdminRoleController(IRoleService roleService)
        {
            this.roleService = roleService;
        }


        public ActionResult Index() => View(RoleManager.Roles);

        public ActionResult Create() => View();

        [HttpPost]
        public async Task<ActionResult> Create([Required]string name)
        {
            if(ModelState.IsValid)
            {
                IdentityResult result = await RoleManager.CreateAsync(new AppRole(name));

                if (result.Succeeded)
                    return RedirectToAction("Index");
            }
            return View(name);
        }

        [HttpPost]
        public async Task<ActionResult> Delete(string id)
        {
            AppRole role = await RoleManager.FindByIdAsync(id);

            if(role != null)
            {
                IdentityResult result = await RoleManager.DeleteAsync(role);

                if (result.Succeeded)
                    return RedirectToAction("Index");
                else
                    return View("Error", result.Errors);
            }
            else
                return View("Error", new string[] { "Role not found" });
        }

        private AppRoleManager RoleManager { get { return HttpContext.GetOwinContext().GetUserManager<AppRoleManager>(); } }
    }
}