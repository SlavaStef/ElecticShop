using ElectricShop.Common.DTO;
using ElectricShop.Common.Models;
using ElectricShop.Data.Interfaces;
using ElectricShop.Logic.Interfaces;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ElectricShop.Logic.Services
{
    public class UserService : IUserService, IDisposable
    {
        IUnitOfWork _context { get; set; }

        public UserService(IUnitOfWork context)
        {
            _context = context;
        }


        public async Task Create(UserDTO userDTO)
        {
            AppUser user = await _context.UserManager.FindByEmailAsync(userDTO.Email);

            if (user == null)
            {
                user = new AppUser { Email = userDTO.Email, UserName = userDTO.Email };
                IdentityResult result = await _context.UserManager.CreateAsync(user, userDTO.Password);

                if (result.Errors.Count() > 0)
                    throw new Exception();

                await _context.CompleteAsync();
            }
            else
                throw new Exception();
        }

        public async Task<ClaimsIdentity> Authenticate(UserDTO userDTO)
        {
            ClaimsIdentity claim = null;

            AppUser user = await _context.UserManager.FindAsync(userDTO.Email, userDTO.Password);

            if(user != null)
               claim = await _context.UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);

            return claim;

        }

        public async Task SetInitialData(UserDTO adminDTO, List<string> roles)
        {
            foreach(string roleName in roles)
            {
                AppRole role = await _context.RoleManager.FindByNameAsync(roleName);

                if(role == null)
                {
                    role = new AppRole { Name = roleName };
                    await _context.RoleManager.CreateAsync(role);
                }
            }

            await Create(adminDTO);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}