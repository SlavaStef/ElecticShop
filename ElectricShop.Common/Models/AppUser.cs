using Microsoft.AspNet.Identity.EntityFramework;

namespace ElectricShop.Common.Models
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
    }
}