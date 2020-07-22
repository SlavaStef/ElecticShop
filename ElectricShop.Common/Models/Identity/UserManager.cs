
using Microsoft.AspNet.Identity;

namespace ElectricShop.Common.Models.Identity
{
    public class UserManager : UserManager<AppUser>
    {
        public UserManager(IUserStore<AppUser> store) : base(store) { }
    }
}
