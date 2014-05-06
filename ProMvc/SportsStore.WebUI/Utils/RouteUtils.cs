using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SportsStore.WebUI.Utils
{
    public static class RouteUtils
    {
        #region 
        /// <summary>
        /// get route data from current request
        /// </summary>
        /// <param name="controller"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetRouteData(this Controller controller, string key)
        {
            return (string)controller.RouteData.Values[key];
        }

        /// <summary>
        /// tell the MVC Framework to look only in the namespaces that we specify.
        /// </summary>
        /// <param name="route"></param>
        /// <param name="fallback"></param>
        public static void UseNamespaceFallback(Route route, bool fallback = false)
        {
            route.DataTokens["UseNamespaceFallback"] = fallback;
        }

        /// <summary>
        /// the default is match a file on disk then use route
        /// </summary>
        /// <param name="routes"></param>
        /// <param name="route"></param>
        public static void RouteExistingFile(RouteCollection routes, bool route = true)
        {
            routes.RouteExistingFiles = route;
        }
        #endregion

        #region generating outgoing file



        #endregion
    }
}