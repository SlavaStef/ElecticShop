using ElectricShop.Data.Interfaces;
using ElectricShop.Data.Repositories;
using ElectricShop.Logic.Interfaces;
using ElectricShop.Logic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricShop.Logic
{
    public class ServiceCreator
    {
        IUnitOfWork _context { get; set; }

        public ServiceCreator(IUnitOfWork context)
        {
            _context = context;
        }

        public ServiceCreator() { }


        public IUserService CreateUserService()
        {
            return new UserService(_context);
        }
    }
}