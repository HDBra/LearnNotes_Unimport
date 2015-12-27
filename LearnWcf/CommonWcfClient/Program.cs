using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonWcfClient
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceClient client = new ServiceClient())
            {
                Console.WriteLine(client.GetData(1));
            }
        }
    }
}
