using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace CommonWcfServiceLibrary.Utils
{
    /// <summary>
    /// 对外提供一组service
    /// </summary>
    public class ServiceHostListHelper : IDisposable
    {

        #region 单例

        /// <summary>
        /// 单例
        /// </summary>
        private static volatile ServiceHostListHelper _instance;

        /// <summary>
        /// 私有构造函数
        /// </summary>
        private ServiceHostListHelper()
        {

        }

        /// <summary>
        /// 对外提供单例服务
        /// </summary>
        /// <returns></returns>
        public static ServiceHostListHelper GetInstance()
        {
            if (_instance != null)
            {
                return _instance;
            }

            if (_instance == null)
            {
                _instance = new ServiceHostListHelper();
            }

            return _instance;
        }


        #endregion

        #region Private Member

        /// <summary>
        /// 是否打开所有的host，以便客户端可以连接
        /// </summary>
        private bool isAllOpened;

        /// <summary>
        /// the host list to the service
        /// </summary>
        private ServiceHost[] _hostList;

        #endregion


        #region Public Method

        /// <summary>
        /// ServiceHost载入服务时，会到配置文件中的<services>下找有没有name属性跟服务配置的，并加载该配置
        /// </summary>
        /// <param name="serviceTypeArr">承载服务的类型。</param>
        /// <param name="baseAddresses">Uri 类型的数组，包含承载服务的基址。</param>
        public bool Open(Type[] serviceTypeArr, params Uri[] baseAddresses)
        {
            //首先关闭连接，如果已经连接
            Stop();
            try
            {
                //另有泛型的ServiceHost<T>
                _hostList = new ServiceHost[serviceTypeArr.Length];

                for (int i = 0; i < _hostList.Length; i++)
                {
                    _hostList[i] = new ServiceHost(serviceTypeArr[i], baseAddresses);

                    //_host.AddServiceEndpoint();//添加Endpoint
                    //_host.Description.Behaviors.Add();//添加行为
                    _hostList[i].Open();
                }


                isAllOpened = true;
            }
            catch (Exception ex)
            {
                isAllOpened = false;
            }

            return isAllOpened;
        }

        /// <summary>
        /*
                * 1、如果注册多个服务需要多个host
                * 2、基地址可以在构造函数中指定，也可在配置文件中指定（建议在配置文件中） 如：new Uri("http://localhost:19830/CmluService")  Host将会使用配置文件中的基地址和构造函数中提供的基地址的组合。
                * 3、ServiceHost载入服务时，会到配置文件中的<services>下找有没有name属性跟服务配置的，并加载该配置
                */
        /// </summary>
        /// <param name="serviceTypeArr">承载服务的类型。 如： typeof(Service1)</param>
        /// <returns></returns>
        public bool Open(params Type[] serviceTypeArr)
        {
            //首先关闭连接，如果已经连接
            Stop();

            try
            {
                /*
             * 1、如果注册多个服务需要多个host
             * 2、基地址可以在构造函数中指定，也可在配置文件中指定（建议在配置文件中） 如：new Uri("http://localhost:19830/CmluService")  Host将会使用配置文件中的基地址和构造函数中提供的基地址的组合。
             */
                _hostList = new ServiceHost[serviceTypeArr.Length];

                for (int i = 0; i < _hostList.Length; i++)
                {
                    _hostList[i] = new ServiceHost(serviceTypeArr[i]);
                    //_hostList[i].CloseTimeout = new TimeSpan(0, 1, 0);

                    //注册各种监听事件
                    //Faulted 表示通信对象发生错误，无法恢复且不可再用
                    //_host.Faulted +=;
                    //_host.Closed +=;
                    //_host.Opened +=;

                    //通常通过配置文件来添加 Endpoint 和 Behavior
                    //_host.AddServiceEndpoint();//添加Endpoint
                    //_host.Description.Behaviors.Add();//添加行为
                    //Binding wsBinding = new WSHttpBinding();
                    //MyService是相对于基地址的，如果你没有定义endpoint(在配置或者代码中)，wcf使用默认的Endpoint. WCF 从基地址中推断出binding,并使用基地址作为endpoint的地址。 Http使用 BasicHttpBinding
                    //host.AddServiceEndpoint(typeof(IMyContract),wsBinding,"MyService");
                    //绑定事件

                    _hostList[i].Open();
                }

                isAllOpened = true;
            }
            catch (Exception ex)
            {
                isAllOpened = false;
            }

            return isAllOpened;
        }

        /// <summary>
        /// 关闭底层Host连接
        /// </summary>
        public void Stop()
        {
            if (_hostList != null)
            {
                for (int i = 0; i < _hostList.Length; i++)
                {
                    ServiceHost host = _hostList[i];
                    if (host == null)
                    {
                        continue;
                    }
                    try
                    {
                        
                        //by calling the Close() method, you gracefully exit the host instance, allowing calls in progress to complete while refusing future client calls
                        host.Close();
                    }
                    catch (Exception)
                    {
                        //Abort is an ungraceful exit, when called, it immediately aborts all service call in progress and shut down the host.
                        host.Abort();
                    }
                }
            }
            isAllOpened = false;
            _hostList = null;
        }

        #endregion


        #region IDisposable接口

        /// <summary>
        /// 构造函数
        /// </summary>
        public void Dispose()
        {
            Stop();
        }
        #endregion
    }
}
