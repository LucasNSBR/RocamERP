using System.Web.Mvc;
using System.Web.Routing;

namespace RocamERP.Presentation.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
               name: "Default",
               url: "{controller}/{action}/{id}",
               defaults: new { area = "Plataforma", controller = "Estados", action = "Index", id = UrlParameter.Optional }
           );

            routes.MapRoute(
                name: "Default2",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "RocamERP.Presentation.Web.Controllers" }
            );
        }
    }
}
