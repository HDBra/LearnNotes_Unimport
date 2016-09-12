using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using CommonWcfServiceLibrary;
using CommonWcfServiceLibrary.Removable.Models;
using Ninject;
using Ninject.Web.Common;

namespace IISSvcHost
{
    public class Global : HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

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

        }

        ///// <summary>
        ///// 重载 提供kernel
        ///// </summary>
        ///// <returns></returns>
        //protected override Ninject.IKernel CreateKernel()
        //{
        //    var kernel = new StandardKernel();
        //    //绑定disposable对象在requestscope中
        //    kernel.Bind<DisposableModel>().ToSelf().InRequestScope();
        //    return kernel;
        //}
    }
}