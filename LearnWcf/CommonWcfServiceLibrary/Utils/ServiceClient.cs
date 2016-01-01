using System;
using System.Linq.Expressions;
using System.ServiceModel;

namespace CommonWcfServiceLibrary.Utils
{
    /// <summary>
    /// Service is hosted, now we need to implement the proxy class for the client. There are different ways of creating the proxy 
    /// •Using SvcUtil.exe, we can create the proxy class and configuration file with end points.
    /// •Adding Service reference to the client application.
    /// •Implementing ClientBase<T> class
    /// Of these three methods, Implementing ClientBase<T> is the best practice. 
    /// 手动建立代理的步骤如下：
    ///     将服务约定即接口添加到客户端（可以通过粘贴代码或者将接口放到公共类库），在服务器端实现协定即可，客户端不需要。
    ///     服务端和客户端接口名方法名，返回值和参数类型必须一致
    /// </summary>
    public class ServiceClient<T>:ClientBase<T>,IDisposable where T:class//T指的是服务接口
    {
        #region 构造函数
        public ServiceClient()
        {
            //使用应用程序配置文件中的默认目标终结点初始化 ClientBase<TChannel> 类的新实例。
            //如果只有一个与服务接口T匹配的终结点配置，默认构造函数会自动匹配到
        }

        public ServiceClient(string endpointConfigurationName)
        {
            //使用应用程序配置文件中由 endpointConfigurationName 指定的配置信息来初始化 ClientBase<TChannel> 类的新实例。
        }
        #endregion

        #region 通过channel调用T接口的方法

        /*
         * 这里可以定制重试次数，异常处理
         */

        //public string GetData(int value)
        //{
        //    return base.Channel.GetData(value);
        //}

        /// <summary>
        /// 获取用于与服务进行通信的内部通道。
        /// 实际上通过它进行服务调用
        /// </summary>
        public T Client
        {
            get { return Channel; }
        }

        /// <summary>
        /// 代理方法
        /// </summary>
        /// <param name="action"></param>
        public static void DoAction(Action<ServiceClient<T>> action)
        {
            using (ServiceClient<T> client = new ServiceClient<T>())
            {
                action(client);
            }
        }

        /// <summary>
        /// 代理方法
        /// </summary>
        /// <param name="func"></param>
        public static TResult DoFunc<TResult>(Func<ServiceClient<T>,TResult> func) 
        {
            using (ServiceClient<T> client = new ServiceClient<T>())
            {
                return func(client);
            }
        }

        #endregion


        #region 实现Disposable接口

        /// <summary>
        /// 显式接口实现
        /// </summary>
        void IDisposable.Dispose()
        {
            try
            {
                try
                {
                    if (State != CommunicationState.Closed)
                    {
                        //指示通信对象已关闭，且不再可用
                        base.Close();
                    }
                }
                catch (CommunicationException)
                {
                    base.Abort();
                }
                catch (TimeoutException)
                {
                    base.Abort();
                }
                catch (Exception)
                {
                    base.Abort();
                }
            }
            catch
            {
                
            }
        }
        
        #endregion
    }
}
