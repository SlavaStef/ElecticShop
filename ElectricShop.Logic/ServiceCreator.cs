using AutoMapper;
using ElectricShop.Data.Interfaces;
using ElectricShop.Logic.Interfaces;
using ElectricShop.Logic.Services;

namespace ElectricShop.Logic
{
    public class ServiceCreator
    {
        IUnitOfWork _context { get; set; }
        IMapper _mapper { get; set; }

        public ServiceCreator(IUnitOfWork context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ServiceCreator() { }


        public IUserService CreateUserService()
        {
            return new UserService(_context, _mapper);
        }

        public IRoleService CreateRoleService()
        {
            return new RoleService(_context);
        }
    }
}