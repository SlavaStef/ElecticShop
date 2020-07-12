﻿using ElectricShop.Identity.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;

namespace ElectricShop.Identity.Infrastructure
{
    public class AppRoleManager : RoleManager<AppRole> , IDisposable
    {
        public AppRoleManager(RoleStore<AppRole> store) : base(store) { }

        public static AppRoleManager Create(IdentityFactoryOptions<AppRoleManager> options, IOwinContext context) => new AppRoleManager(new RoleStore<AppRole>(context.Get<AppIdentityDbContext>()));
    }
}