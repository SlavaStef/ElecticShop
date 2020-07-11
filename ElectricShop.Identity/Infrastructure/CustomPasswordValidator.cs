﻿using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricShop.Identity.Infrastructure
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