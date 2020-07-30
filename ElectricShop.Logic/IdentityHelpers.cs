using ElectricShop.Logic.Interfaces;
using System.Web.Mvc;

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
