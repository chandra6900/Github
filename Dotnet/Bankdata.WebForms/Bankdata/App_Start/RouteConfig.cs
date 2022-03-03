using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Bankdata
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
               name: "AccountDefault",
               url: "Account/{action}/{id}",
               defaults: new { controller = "Account", action = "LogIn", id = UrlParameter.Optional }
           );
            routes.MapRoute(
               name: "LogInDefault",
               url: "Home/LogIn",
               defaults: new { controller = "Account", action = "LogIn", id = UrlParameter.Optional }
           );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

        }
    }
}