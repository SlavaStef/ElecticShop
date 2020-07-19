using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ElectricShop.Infrastructure.Models.Identity
{
    class CustomPasswordValidator : PasswordValidator
    {
        public override async Task<IdentityResult> ValidateAsync(String pass)
        {
            IdentityResult result = await base.ValidateAsync(pass);
            if(pass.Contains("12345"))
            {
                var errors = result.Errors.ToList();
                errors.Add("Passwords canot contain numeric sequences");
                result = new IdentityResult(errors);
            }
            return result;
        }
    }
}
