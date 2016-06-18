using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace CommonWcfClient
{
    class Program
    {
        static void Main(string[] args)
        {
            using (HandWriteProxy proxy = new HandWriteProxy())
            {
                Console.WriteLine(proxy.GetData(2));
            }
        }
    }
}
