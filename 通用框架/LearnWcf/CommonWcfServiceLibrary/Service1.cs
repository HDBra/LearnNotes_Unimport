using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CommonWcfServiceLibrary
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的类名“Service1”
    /// <summary>
    /// PerCall :  新的 InstanceContext 对象在每次调用前创建，在调用后回收。
    /// PerSession: 为每个会话创建一个新的 InstanceContext 对象。PerSession是默认的
    /// Single  : 只有一个 InstanceContext 对象用于所有传入呼叫，并且在调用后不回收。如果服务对象不存在，则创建一个。
    /// 
    /// 注：Service类可以实现IDisposable
    /// 建议采用PerCall，不采用Session
    /// </summary>
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0} and time is {1}", value, DateTime.Now.ToString("yyyyMMdd HH:mm:ss"));
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
