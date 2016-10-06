using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace LearnWebApi2
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //注册web api路由
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
