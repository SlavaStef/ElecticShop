using ElectricShop.Common.Models;
using ElectricShop.Logic.Interfaces;
using ElectricShop.Logic.Services;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
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
        IUserService userService { get; set; }

        public AdminRoleController(IRoleService roleService, IUserService userService)
        {
            this.roleService = roleService;
            this.userService = userService;
        }


        public async Task<ActionResult> Index() => View(await roleService.GetRoles());

        public ActionResult Create() => View();

        [HttpPost]
        public async Task<ActionResult> Create([Required]string name)
        {
            if(ModelState.IsValid)
            {
                IdentityResult createResult = await roleService.CreateRole(name);

                if (createResult.Succeeded)
                    return RedirectToAction("Index");
            }
            return View(name);
        }

        public async Task<ActionResult> Edit(string id)
        {
            AppRole role = await roleService.GetRole(id);
            string[] memberIDs = role.Users.Select(x => x.UserId).ToArray();

            IEnumerable<AppUser> users = await userService.GetUsers();

            IEnumerable<AppUser> members = users.Where(x => memberIDs.Any(y => y == x.Id));
            IEnumerable<AppUser> nonMembers = users.Except(members);

            return View(new RoleEditModel { Role = role, Members = members, NonMembers = nonMembers });
        }

        [HttpPost]
        public async Task<ActionResult> Edit(RoleModificationModel model)
        {
            IdentityResult result;

            if (ModelState.IsValid)
            {
                foreach (string userId in model.IdsToAdd ?? new string[] { })
                {
                    result = await userService.AddToRole(userId, model.RoleName);

                    if (!result.Succeeded)
                        return View("Error", result.Errors);
                }

                foreach (string userId in model.IdsToDelete ?? new string[] { })
                {
                    result = await userService.RemoveFromRole(userId,
                        model.RoleName);

                    if (!result.Succeeded)
                        return View("Error", result.Errors);
                }

                return RedirectToAction("Index");
            }
            return View("Error", new string[] { "Role not found" });
        }

        [HttpPost]
        public async Task<ActionResult> Delete(string id)
        {
            IdentityResult deleteResult = await roleService.DeleteRole(id);
            
            if(deleteResult.Succeeded)
                return RedirectToAction("Index");
            
            return View("Error", deleteResult.Errors);
        }

    }
}