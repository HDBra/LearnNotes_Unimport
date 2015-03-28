using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfInterface
{
    /// <summary>
    /// Tips:
    /// 1:Always create the service with interface->Implementation format, mention the contract in interface.
    /// 2:Define the service in class library and refer the class library in host project. Don't use service class in host project.
    /// </summary>
    [ServiceContract]
    public interface IWcfService
    {
        [OperationContract]
        int Add(int num1, int num2);

        [OperationContract]
        int Substract(int num1, int num2);

        [OperationContract]
        int Multiply(int num1, int num2);

        [OperationContract]
        int Divide(int num1, int num2);

    }

    // 使用下面示例中说明的数据约定将复合类型添加到服务操作。

    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
