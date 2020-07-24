using ElectricShop.Data.Interfaces;
using ElectricShop.Logic.Interfaces;
using ElectricShop.Logic.Services;

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