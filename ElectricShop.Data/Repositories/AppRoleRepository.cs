using ElectricShop.Data.Context;
using ElectricShop.Infrastructure.Models.Identity;

namespace ElectricShop.Data.Repositories
{
    public class AppRoleRepository : Repository<AppRole>
    {
        public AppRoleRepository(IdentityContext context) : base(context) { }
    }
}
