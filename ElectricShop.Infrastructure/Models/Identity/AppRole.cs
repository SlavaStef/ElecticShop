using Microsoft.AspNet.Identity.EntityFramework;

namespace ElectricShop.Infrastructure.Models.Identity
{
    public class AppRole : IdentityRole
    {
        public AppRole() : base() { }

        public AppRole(string name) : base(name) { }
    }
}
