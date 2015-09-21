using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace StandardMVC
{
    /// <summary>
    /// The ASP.NET framework will create multiple instances of the MvcApplication class to process requests, and
    /// these instances can be reused so that they process several requests over their lifetime.The ASP.NET framework
    /// has complete freedom to create MvcApplication instances as and when they are required and to destroy them
    /// when they are no longer needed.This means your global application class must be written so that multiple
    /// instances can exist concurrently and that these instances can be used to process several requests sequentially
    /// before they are destroyed.The only thing you can rely on is that each instance will be used to process one
    /// request at a time, meaning you have to worry only about concurrent access to data objects that are shared
    /// </summary>
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }


        protected void Application_End(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// This is triggered as the first event when a new request is received.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// This event is triggered when the request has been processed and the response is ready to be sent to the browser.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Application_EndRequest(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// This event is triggered when an error is encountered; this can happen at any point in the request process.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Application_Error(object sender, EventArgs e)
        {
            Exception ex = Server.GetLastError().GetBaseException();
        }
    }
}
