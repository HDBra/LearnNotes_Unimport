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
            string s = @"\\mt-data\training_archive\mtmain_backend\ENU_TAM_GENERAL\vCurrent\2014_03_28_08H_13m_37S";
            var r = Regex.IsMatch(Path.GetFileName(s), @"^\d{4}_\d{2}_\d{2}_\d{2}h_\d{2}m_\d{2}s$");
            Console.WriteLine(r);
            /*
             * local service: onCreate onStartCommand onDestory
             * remote service: onCreate onBind onDestory
             * Activity: onCreate onStart onResume onPause onStop onDestory
             * Fragment: onAttach onCreate onCreateView onActivityCreated onStart onResume onPause onStop onDestoryView onDestory onDetach
             * #id .class element element#id element.class [attr] [attr="value"] [attr*="value"] element[attr] element[attr="value"] element[attr*="value"] ,group  descendant >children ~all siblings +first sibling
             * snbao:String Number Boolean Array Object
             * fwghso: FROM WHERE GROUP HAVING SELECT ORDERBY
             * selection sort quick sort merge sort heap sort insertion sort counting sort radix sort bucket sort
             * avl:|size(node.left)-size(node.right)|<=1
             * sbt: size(node.left)>=size(node.right.left) size(node.right.right)  size(node.right)>=size(node.left.right) size(node.left.left)
             * treap:assign a node a priority, node.priority<=node.left.priority node.priority<=node.right.priority node.key<= node.right.key node.key>=node.left.key the nodes are inserted as if they come in sequence of priority
             * splay tree: move the lastest visited node to the root.
             * rbt: the tree have red or black two color . if a node is red, then its chilren can't be red. all path from a node to its leaf have same black depth.
             * b tree:define t as min degree. each nonroot node have [t-1,2t-1] keys have [t,2t] nodes all leaf have same depth
             * dynamic programming:optimal subproblem & subproblem override
             * greedy algorithm: choose the best choice for now & hope it works for all
             * 
             */
            Console.Title = "Stock checker";
            WebClient webClient = new WebClient();
            webClient.Encoding = Encoding.GetEncoding("gbk");
            Console.WindowWidth = 60;
            Console.WindowHeight = 8;
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
                        list.Add(string.Format("{3}{1}{2}{0}{4}", item.PadRight(12), message[2].PadRight(12), message[3].PadRight(13), Math.Round(((double.Parse(message[3]) - double.Parse(message[2])) / double.Parse(message[2])), 5).ToString().PadRight(12), DateTime.Now.ToLongTimeString()));
                        SetWindowPos(FindWindow("ConsoleWindowClass", "Stock checker"), -1, 0, 0, 0, 0, 1 | 2);

                        double bleu = Math.Round(((double.Parse(message[3]) - double.Parse(message[2])) / double.Parse(message[2])), 5);
                        if (item == "sh000001" && Math.Abs(bleu)>0.01)
                        {
                            Thread.Sleep(2000);
                            Console.Beep();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                list.ForEach(Console.WriteLine);
                Console.WriteLine("===============================================");
                Thread.Sleep(900);
            }
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int y, int Width, int Height, int flags);
        [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern System.IntPtr GetForegroundWindow();

        static string[] Stocks = { "sh000001", "sh600060", "sz000100", "sh600839", "sz000016", "sz000725", "sh601688", "sh601328", "sz000930", "sh600308" };
        const string ApiNet = @"http://hq.sinajs.cn/list=";
    }
}
