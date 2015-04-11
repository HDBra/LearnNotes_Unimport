using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Socket
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * #id .class element element#id element.class [attr] [attr="value"] [attr*="value"] element[attr] element[attr="value"] element[attr*="value"] ,group  descendant >children ~allsibling +first sibling
             * fwghso:from where group having select orderby
             * snbao:String Number Boolean Array Object
             * onCreate onStart onResume onPause onStop onDestory
             * onAttach oncreate oncreateview onActivityCreated onstart onresume onpause onstop ondestoryview ondestory ondetach
             * activity servie contentprovider broadcastreceiver
             * avl:|size(node.left)-size(node.right)|<=1
             * sbt:size(node.left)>=size(node.right.left) size(node.right.right)  size(node.right)>=size(node.left.right) size(node.left.left)
             * rbt: the root is black.if a node is red, then its children can't be red. all paths from a node to its leaf have same black depth.
             * treap:assign each node a priority, node.priority<=node.children.priority,  node.left.key=<node.key<=node.right.key
             * splay tree: move the lastest visited node to the root.
             * b tree:define t (t>=2) as min degree. each nonroot node has [t-1,2t-1] key & [t,2t] children. all leaf are at same depth.
             * greedy algorithm: choose the best choice for now & hope it works for all.
             * dynamic programming: optimal subproblems & subproblems override
             * heapsort quicksort merge sort insertion sort selection sort bubblesort bucket sort countingsort radix sort
             */

            Console.Title = "ontop";
            WebClient webClient = new WebClient();
            
            webClient.Encoding = Encoding.GetEncoding("gbk");
            Console.WindowWidth = 10;
            Console.WindowHeight = 4;
            while (true)
            {
                List<string> list = new List<string>();
                try
                {
                    foreach (var item in Stocks)
                    {
                        string address = ApiNet + item;
                        string result = webClient.DownloadString(address);
                        string[] message = (result.Split(new char[] { '=' }, 2)[1]).Trim().Trim(';', '\"').Split(',');
                        //list.Add(string.Format("{3}{1}{2}{0}{4}", item.PadRight(12), message[2].PadRight(12), message[3].PadRight(13), Math.Round(((double.Parse(message[3]) - double.Parse(message[2])) / double.Parse(message[2])), 5).ToString().PadRight(12), DateTime.Now.ToLongTimeString()));
                        list.Add(Math.Round(((double.Parse(message[3]) - double.Parse(message[2])) / double.Parse(message[2])), 5).ToString().PadRight(12));
                        SetWindowPos(FindWindow("ConsoleWindowClass", Console.Title), -1, 0, 0, 0, 0, 1 | 2);

                        Console.WindowWidth = 10;
                        Console.WindowHeight = 6;
                        
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                list.ForEach(Console.WriteLine);
                Console.WindowWidth = 10;
                Console.WindowHeight = 6;
                Console.WriteLine("===============================================");
                Thread.Sleep(1600);
            }
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int y, int Width, int Height, int flags);
        [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern System.IntPtr GetForegroundWindow();

        static string[] Stocks = { "sh000001","sz002024","sz000898"};
        const string ApiNet = @"http://hq.sinajs.cn/list=";
    }
}
