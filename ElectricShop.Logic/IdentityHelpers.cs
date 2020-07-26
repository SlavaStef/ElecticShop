using ElectricShop.Common.Models;
using ElectricShop.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using System.Web;

namespace ElectricShop.Logic
{
    public static class IdentityHelpers
    {
        public static MvcHtmlString GetUserName(this HtmlHelper html, string id)
        {
            ServiceCreator userService = new ServiceCreator();
            IUserService manager = userService.CreateUserService();

            return new MvcHtmlString(manager.GetUser(id).Result.UserName);
        }
    }
}
