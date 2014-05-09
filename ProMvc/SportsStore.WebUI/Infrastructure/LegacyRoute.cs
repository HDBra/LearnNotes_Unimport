using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace SportsStore.WebUI.Infrastructure
{
    public class LegacyRoute:RouteBase
    {
        private string[] urls;

        public LegacyRoute(params string[] targetUrls)
        {
            urls = targetUrls;
        }

        public override RouteData GetRouteData(HttpContextBase httpContext)
        {
            throw new NotImplementedException();
        }

        public override VirtualPathData GetVirtualPath(RequestContext requestContext, RouteValueDictionary values)
        {
            throw new NotImplementedException();
        }
    }
}