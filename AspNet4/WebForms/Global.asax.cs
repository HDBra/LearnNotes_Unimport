using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using WebForms.Models;

namespace WebForms
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            EventCollection.Add(EventSource.Application, "Start");
            Application["message"] = "Application Events";
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            EventCollection.Add(EventSource.Application, "BeginRequest");

        }

        protected void Application_EndRequest(object sender, EventArgs e)
        {
            EventCollection.Add(EventSource.Application, "EndRequest");
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {
            EventCollection.Add(EventSource.Application, "End");
        }
    }
}