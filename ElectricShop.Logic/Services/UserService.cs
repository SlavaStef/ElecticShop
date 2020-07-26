using ElectricShop.Common.DTO;
using ElectricShop.Common.Models;
using ElectricShop.Data.Context;
using ElectricShop.Data.Interfaces;
using ElectricShop.Logic.Interfaces;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ElectricShop.Logic.Services
{
    public class UserService : IUserService
    {
        IUnitOfWork context { get; set; }

        public UserService(IUnitOfWork context)
        {
            this.context = context;
        }


        //Show all users
        public async Task<IEnumerable<AppUser>> GetUsers() => await context.UserManager.Users.ToListAsync();

        //Create a user
        public async Task<IdentityResult> CreateUser(AppUser user, string password)
        {
            IdentityResult createResult = null;

            if (await context.UserManager.FindByEmailAsync(user.Email) == null)
            {
                createResult = await context.UserManager.CreateAsync(user, password);
                
                if(createResult.Succeeded)
                    await context.CompleteAsync();
            }

            return createResult;                
        }

        //Delete a user
        public async Task<IdentityResult> DeleteUser(string Id)
        {
            AppUser user = await context.UserManager.FindByIdAsync(Id);
            IdentityResult deleteResult = null;

            if(user != null)
            {
                deleteResult = await context.UserManager.DeleteAsync(user);

                if (deleteResult.Succeeded)
                    await context.CompleteAsync();
            }

            return deleteResult;            
        }

        //Edit a user

        //Login

        //Logout

        public async Task Create(UserDTO userDTO)
        {
            AppUser user = await context.UserManager.FindByEmailAsync(userDTO.Email);

            if (user == null)
            {
                user = new AppUser { Email = userDTO.Email, UserName = userDTO.Email };
                IdentityResult result = await context.UserManager.CreateAsync(user, userDTO.Password);

                if (result.Errors.Count() > 0)
                    throw new Exception();

                await context.CompleteAsync();
            }
            else
                throw new Exception();
        }

        public AppUserManager CreateAppUserManager(IdentityFactoryOptions<AppUserManager> options, IOwinContext context)
        {
            //ApplicationContext db = context.Get<ApplicationContext>();
            //var db = new ApplicationContext();
            AppUserManager manager = new AppUserManager(new UserStore<AppUser>(new ApplicationContext()));

            return manager;
        }

        public async Task<ClaimsIdentity> Authenticate(UserDTO userDTO)
        {
            ClaimsIdentity claim = null;

            AppUser user = await context.UserManager.FindAsync(userDTO.Email, userDTO.Password);

            if(user != null)
               claim = await context.UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);

            return claim;

        }

        public async Task SetInitialData(UserDTO adminDTO, List<string> roles)
        {
            foreach(string roleName in roles)
            {
                AppRole role = await context.RoleManager.FindByNameAsync(roleName);

                if(role == null)
                {
                    role = new AppRole { Name = roleName };
                    await context.RoleManager.CreateAsync(role);
                }
            }

            await Create(adminDTO);
        }

        public void Dispose()
        {
            //context.Dispose();
        }
    }
}