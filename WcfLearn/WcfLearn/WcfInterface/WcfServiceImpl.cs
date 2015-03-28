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
    public class WcfServiceImpl : IWcfService
    {
        public int Add(int num1, int num2)
        {
            return num1 + num2;
        }

        public int Substract(int num1, int num2)
        {
            return num1 - num2;
        }

        public int Multiply(int num1, int num2)
        {
            return num1 * num2;
        }

        public int Divide(int num1, int num2)
        {
            return num2 == 0 ? 0 : num1 / num2;
        }
    }
}
