using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WcfInterface;

namespace SelfHost
{
    class Program
    {
        static void Main(string[] args)
        {
            Uri tcpBaseAddress = new Uri("net.tcp://localhost:8001/");
            ServiceHost host = new ServiceHost(typeof(WcfServiceImpl));
            host.Open();
            Console.WriteLine("hello");
            Console.ReadLine();

            host.Close();
        }
    }
}
