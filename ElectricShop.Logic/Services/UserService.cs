using AutoMapper;
using ElectricShop.Common.DTO;
using ElectricShop.Common.Models;
using ElectricShop.Common.ViewModels;
using ElectricShop.Data.Context;
using ElectricShop.Data.Interfaces;
using ElectricShop.Logic.Interfaces;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System.Collections.Generic;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ElectricShop.Logic.Services
{
    public class UserService : IUserService
    {
        IUnitOfWork context { get; set; }
        IMapper mapper { get; set; } 

        public UserService(IUnitOfWork context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }


        public async Task<UserDTO> GetUser(string id)
        {
            AppUser user = await context.UserManager.FindByIdAsync(id);

            return mapper.Map<UserDTO>(user);
        }

        public async Task<IEnumerable<UserDTO>> GetUsers()
        {
            List<AppUser> users = await context.UserManager.Users.ToListAsync();

            return mapper.Map<List<UserDTO>>(users);
        }
        
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

        public async Task<IdentityResult> EditUser(UserDTO user)
        {
            AppUser _user = await context.UserManager.FindByIdAsync(user.Id);

            _user = mapper.Map(user, _user);

            IdentityResult userValid = await context.UserManager.UserValidator.ValidateAsync(_user);
            IdentityResult updateResult = null;

            if (userValid.Succeeded)
            {
                updateResult = await context.UserManager.UpdateAsync(_user);
            }

            return updateResult;
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

        public async Task<ClaimsIdentity> Authenticate(LoginViewModel model)
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