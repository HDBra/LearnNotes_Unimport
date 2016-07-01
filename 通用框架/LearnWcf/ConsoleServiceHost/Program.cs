using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using CommonWcfServiceLibrary;

namespace ConsoleServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                using (ServiceHost host = new ServiceHost(typeof (Service1)))
                {
                    host.Open();
                    Console.WriteLine(host.State);
                    Console.WriteLine("开始接受信息");
                    Console.ReadLine();
                    Console.ReadLine();
                    Console.ReadLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.ReadLine();
            }
        }
    }
}
