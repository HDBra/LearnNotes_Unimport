using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SportsStore.WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("NewRoute", "App/Do{action}", new { controller = "Home" });

            routes.MapRoute("startPage", "{controller}/{action}/{id}", new { controller = "Home", action = "Index", id = UrlParameter.Optional });

        }
    }
}