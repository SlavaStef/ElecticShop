using ElectricShop.Data.Entities;
using ElectricShop.Web.Infrastructure.Binders;
using System.Web.Mvc;
using System.Web.Routing;

namespace ElectricShop.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            ModelBinders.Binders.Add(typeof(Cart), new CartModelBinder());
        }
    }
}
