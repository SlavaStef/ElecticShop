using AutoMapper;
using ElectricShop.Common.DTO;
using ElectricShop.Common.Models;
using ElectricShop.Common.ViewModels;
using ElectricShop.Logic.Interfaces;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ElectricShop.Web.Areas.Admin.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        IUserService userService { get; set; }
        IMapper mapper { get; set; }


        public UserController(IUserService service, IMapper mapper)
        {
            userService = service;
            this.mapper = mapper;
        }


        public async Task<ActionResult> Index() => View(await userService.GetUsers());

        [HttpPost]
        public async Task<ActionResult> Details(string userId)
        {
            UserDTO user = await userService.GetUser(userId);
            return View(user);
        }

        public ActionResult Create() => View();

        [HttpPost]
        public async Task<ActionResult> Create(RegisterViewModel user)
        {
            if(ModelState.IsValid)
            {
                string password = user.Password;
                AppUser _user = mapper.Map<AppUser>(user);
                IdentityResult result = await userService.CreateUser(_user, password);

                if (result.Succeeded)
                    return RedirectToAction("Index");
            }
            return View(user);
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
            UserDTO user = await userService.GetUser(id);

            if (user != null)
                return View(user);
            else
                return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<ActionResult> Edit(UserDTO user)
        {
            IdentityResult editResult = await userService.EditUser(user);

            if(editResult.Succeeded)
                return RedirectToAction("Index");
                    
            return View(await userService.GetUser(user.Id));
        }
    }
}