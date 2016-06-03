using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace com.Zdjhtx
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(name: "html", url: "{controller}/{action}.html");
            routes.MapRoute(name: "do", url: "{controller}/{action}.do");
            routes.MapRoute(name: "api", url: "{controller}/{action}.api");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "PhoneFees", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}