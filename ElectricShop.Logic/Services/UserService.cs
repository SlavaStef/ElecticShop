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


        public async Task<IEnumerable<AppUser>> GetUsers() => await context.UserManager.Users.ToListAsync();

        public async Task<AppUser> GetUser(string id) => await context.UserManager.FindByIdAsync(id);

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

        public async Task<IdentityResult> EditUser(string id, string email, string password)
        {
            IdentityResult updateResult = null;
            AppUser user = await context.UserManager.FindByIdAsync(id);

            user.Email = email;
            IdentityResult validEmail = await context.UserManager.UserValidator.ValidateAsync(user);

            IdentityResult validPass = null;
            if (password != string.Empty)
            {
                validPass = await context.UserManager.PasswordValidator.ValidateAsync(password);
                if (validPass.Succeeded)
                    user.PasswordHash = context.UserManager.PasswordHasher.HashPassword(password);
            }

            if ((validEmail.Succeeded && validPass == null) || (validEmail.Succeeded && password != string.Empty && validPass.Succeeded))
            {
                updateResult = await context.UserManager.UpdateAsync(user);    
            }

            return updateResult;
        }

        public async Task<ClaimsIdentity> Authenticate(LoginModel model)
        {
            AppUser user = await context.UserManager.FindAsync(model.Name, model.Password);

            if(user != null)
            {
                ClaimsIdentity claim = await context.UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);

                return claim;
            }

            return null;
        }

        public async Task<IdentityResult> AddToRole(string userId, string roleName) => await context.UserManager.AddToRoleAsync(userId, roleName);

        public async Task<IdentityResult> RemoveFromRole(string userId, string roleName) => await context.UserManager.RemoveFromRoleAsync(userId, roleName);




        public AppUserManager CreateAppUserManager(IdentityFactoryOptions<AppUserManager> options, IOwinContext context)
        {
            //ApplicationContext db = context.Get<ApplicationContext>();
            //var db = new ApplicationContext();
            AppUserManager manager = new AppUserManager(new UserStore<AppUser>(new ApplicationContext()));

            return manager;
        }

        public void Dispose()
        {
            //context.Dispose();
        }
    }
}