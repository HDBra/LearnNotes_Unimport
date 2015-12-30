using System;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace CommonWcfServiceLibrary.Utils
{
    /// <summary>
    /// ServiceHost单例
    /// Address像如下的格式
    /// Transport://machineordomain:optional port/optional URI
    /// 如：
    /// http://localhost:8001/MyService
    /// net.tcp://localhost:8002/MyService
    /// net.pipe://localhost/MyPipe
    /// net.msmq://localhost/private/MyQueue
    /// net.msmq://localhost/MyQueue
    /// tcp默认端口808 http默认80 https默认443  pipe使用管道进行同一机器的进程通信
    /// </summary>
    public class ServiceHostHelper:IDisposable
    {
        #region 单例

        /// <summary>
        /// 单例
        /// </summary>
        private static ServiceHostHelper _instance;

        #region 私有构造函数
        
        /// <summary>
        /// 构造函数
        /// </summary>
        private ServiceHostHelper()
        {
        }
        #endregion

        /// <summary>
        /// 单例构造函数
        /// </summary>
        /// <returns></returns>
        public static ServiceHostHelper GetInstance()
        {
            if (_instance != null)
            {
                return _instance;
            }

            if (_instance == null)
            {
                _instance = new ServiceHostHelper();
            }

            return _instance;
        }

        #endregion

        #region Private Member

        /// <summary>
        /// 是否打开host，以便客户端可以连接
        /// </summary>
        private bool isOpened;

        /// <summary>
        /// the host to the service
        /// </summary>
        private ServiceHost _host;
        #endregion

        #region Public Method

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serviceType">承载服务的类型。</param>
        /// <param name="baseAddresses">Uri 类型的数组，包含承载服务的基址。</param>
        /// <returns>是否成功打开</returns>
        public bool Open(Type serviceType,params Uri[] baseAddresses)
        {
            //首先关闭连接，如果已经连接
            Stop();
            try
            {
                //另有泛型的ServiceHost<T>
                _host = new ServiceHost(serviceType, baseAddresses);

                //_host.AddServiceEndpoint();//添加Endpoint
                //_host.Description.Behaviors.Add();//添加行为

                _host.Open();
                isOpened = true;
            }
            catch
            {
                isOpened = false;
            }

            return isOpened;
        }

        /// <summary>
         /*
                 * 1、如果注册多个服务需要多个host
                 * 2、基地址可以在构造函数中指定，也可在配置文件中指定（建议在配置文件中） 如：new Uri("http://localhost:19830/CmluService")  Host将会使用配置文件中的基地址和构造函数中提供的基地址的组合。
                 */
        /// </summary>
        /// <param name="serviceType">承载服务的类型。</param>
        /// <returns></returns>
        public bool Open(Type serviceType)
        {
            //首先关闭连接，如果已经连接
            Stop();
            try
            {
                /*
                 * 1、如果注册多个服务需要多个host
                 * 2、基地址可以在构造函数中指定，也可在配置文件中指定（建议在配置文件中） 如：new Uri("http://localhost:19830/CmluService")  Host将会使用配置文件中的基地址和构造函数中提供的基地址的组合。
                 */
                _host = new ServiceHost(serviceType) {CloseTimeout = new TimeSpan(0, 0, 30)};
                //注册各种监听事件
                //Faulted 表示通信对象发生错误，无法恢复且不可再用
                //_host.Faulted +=;
                //_host.Closed +=;
                //_host.Opened +=;

                //_host.AddServiceEndpoint();//添加Endpoint
                //_host.Description.Behaviors.Add();//添加行为
                //Binding wsBinding = new WSHttpBinding();
                //host.AddServiceEndpoint(typeof(IMyContract),wsBinding,"http://localhost:8000/MyService");
                //绑定事件

                _host.Open();
                
                isOpened = true;
            }
            catch
            {
                isOpened = false;
            }

            return isOpened;
        }
        /// <summary>
        /// 关闭底层Host连接
        /// </summary>
        public void Stop()
        {
            if (_host != null)
            {
                try
                {
                    //by calling the Close() method, you gracefully exit the host instance, allowing calls in progress to complete while refusing future client calls
                    _host.Close();
                }
                catch (Exception ex)
                {
                    //Abort is an ungraceful exit, when called, it immediately aborts all service call in progress and shut down the host.
                    _host.Abort();
                }
            }
            isOpened = false;
            _host = null;
        }
        #endregion

        #region Bindings

        /// <summary>
        /// Create WSHttpBinding
        /// </summary>
        /// <returns></returns>
        public static WSHttpBinding CreateWsHttpBinding()
        {
            WSHttpBinding wsHttpBinding = new WSHttpBinding();
            wsHttpBinding.AllowCookies = true;
            wsHttpBinding.CloseTimeout = new TimeSpan(0,0,30);
            wsHttpBinding.SendTimeout = wsHttpBinding.ReceiveTimeout = new TimeSpan(0, 0, 30);
            return wsHttpBinding;
        }

        /// <summary>
        /// Create ServiceMetadataBehavior
        /// </summary>
        /// <returns></returns>
        public static ServiceMetadataBehavior CreateMetadataBehavior()
        {
            ServiceMetadataBehavior behavior = new ServiceMetadataBehavior();
            behavior.HttpGetEnabled = true;
            return behavior;
        }

        #endregion

        #region IDisposable接口
        public void Dispose()
        {
            Stop();
        }
        #endregion
    }
}
