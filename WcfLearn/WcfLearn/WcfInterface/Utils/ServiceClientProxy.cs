using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WcfInterface.Utils
{
    /// <summary>
    /// Service is hosted, now we need to implement the proxy class for the client. There are different ways of creating the proxy 
    /// •Using SvcUtil.exe, we can create the proxy class and configuration file with end points.
    /// •Adding Service reference to the client application.
    /// •Implementing ClientBase<T> class
    /// Of these three methods, Implementing ClientBase<T> is the best practice. 
    /// </summary>
    public class ServiceClientProxy<T>:ClientBase<T> where T:class
    {
    }
}
