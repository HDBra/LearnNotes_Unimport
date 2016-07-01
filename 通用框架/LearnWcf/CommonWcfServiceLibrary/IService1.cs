using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace CommonWcfServiceLibrary
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IService1”。
    /// <summary>
    /// Allowed ： Specifies that the contract supports sessions if the incoming binding supports them,默认的
    /// Required : Specifies that the contract requires a sessionful binding. An exception is thrown if the binding is not configured to support session.
    /// NotAllowed : Specifies that the contract never supports bindings that initiate sessions.
    /// </summary>
    [ServiceContract(SessionMode = SessionMode.Allowed)]
    public interface IService1
    {
        //[OperationContract]
        //string GetData(int value);

        //[OperationContract]
        //CompositeType GetDataUsingDataContract(CompositeType composite);

        /// <summary>
        /// 只能使用webHttpBinding
        /// WebGetAttribute定义了该方法的访问方式为RESTful的Get
        /// UriTemplet描述了URL匹配的格式，当格式匹配时，{name}位置的字符串会被对应传入为方法参数。
        /// ResponseFormat指定json或者xml
        /// 示例
        /// [WebGet(UriTemplate ="Sub?x={x}&y={y}")]
        /// String Subtract(string x, string y);
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [OperationContract]
        [WebGet(UriTemplate = "Persons/{name}",ResponseFormat = WebMessageFormat.Json)]
        Person GetPerson(string name);


        // TODO: 在此添加您的服务操作
    }

    // 使用下面示例中说明的数据约定将复合类型添加到服务操作。
    // 可以将 XSD 文件添加到项目中。在生成项目后，可以通过命名空间“CommonWcfServiceLibrary.ContractType”直接使用其中定义的数据类型。
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


    [DataContract]
    public class Person
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int Age { get; set; }
    }
}
