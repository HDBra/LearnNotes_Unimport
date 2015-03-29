using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WcfInterface.Utils
{
    /// <summary>
    /// ServiceHost单例
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
        /// 关闭底层Host连接
        /// </summary>
        public void Stop()
        {
            if (_host != null)
            {
                try
                {
                    _host.Close();
                }
                catch { }
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
            wsHttpBinding.CloseTimeout = new TimeSpan(0,0,8);
            wsHttpBinding.SendTimeout = wsHttpBinding.ReceiveTimeout = new TimeSpan(0, 0, 8);
            return wsHttpBinding;
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
