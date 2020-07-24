using Microsoft.AspNet.Identity;

namespace ElectricShop.Common.Models
{
    public class AppUserManager : UserManager<AppUser>
    {
        public AppUserManager(IUserStore<AppUser> store) : base(store) { }   
    }
}