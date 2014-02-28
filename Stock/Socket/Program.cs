using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Socket
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Stock checker";
            WebClient webClient = new WebClient();
            webClient.Encoding = Encoding.GetEncoding("gbk");
            Console.WindowWidth = 60;
            Console.WindowHeight = 8;
            while (true)
            {
                //Console.Clear();
                List<string> list = new List<string>();
                try
                {
                    foreach (var item in Stocks)
                    {
                        string address = ApiNet + item;
                        string result = webClient.DownloadString(address);
                        string[] message = (result.Split(new char[] { '=' }, 2)[1]).Trim().Trim(';', '\"').Split(',');
                        list.Add(string.Format("{0}{1}{2}{3}{4}", item.PadRight(12), message[2].PadRight(12), message[3].PadRight(13), Math.Round(((double.Parse(message[3]) - double.Parse(message[2])) / double.Parse(message[2])),5).ToString().PadRight(12),DateTime.Now.ToLongTimeString()));

                        SetWindowPos(FindWindow("ConsoleWindowClass", "Stock checker"), -1, 0, 0, 0, 0, 1 | 2);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                list.ForEach(Console.WriteLine);
                Console.WriteLine("===============================================");
                Thread.Sleep(3000);
            }
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)] 
        private static extern int SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int y, int Width, int Height, int flags);
        [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);


        [DllImport("user32.dll", CharSet = CharSet.Auto)] 
        private static extern System.IntPtr GetForegroundWindow();

        static string[] Stocks = { "sh000001", "sh600060", "sz000100", "sh600839", "sz000016" };
        const string ApiNet = @"http://hq.sinajs.cn/list=";
    }
}
