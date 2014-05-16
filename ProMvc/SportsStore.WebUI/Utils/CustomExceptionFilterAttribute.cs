using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsStore.WebUI.Utils
{
    public class CustomExceptionFilterAttribute:FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            if (filterContext.ExceptionHandled)
            {
                return;
            }

            filterContext.Result = new RedirectResult("~/Content/Error.html");
            filterContext.ExceptionHandled = true;
        }
    }
}