
using Microsoft.AspNet.Identity;

namespace ElectricShop.Common.Models
{
    public class UserManager : UserManager<AppUser>
    {
        public UserManager(IUserStore<AppUser> store) : base(store) { }
    }
}
