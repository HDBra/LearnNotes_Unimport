using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;
using 电报解析.Utils;

namespace 电报解析
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 测试数据库连接
            NLogHelper.Info("测试数据库连接");
            if (SqlHelper.GetInstance(ConfigurationManager.AppSettings["ConnString"]).IsConnectionActive())
            {
                NLogHelper.Info("测试连接数据库成功");
            }
            else
            {
                NLogHelper.Error("连接数据库失败");
                return;
            }
            #endregion

            //初始化消费者队列
            MQConsumer.InitConsumer();
            

           
            String message = null;
            while (true)
            {
                //关闭
                Console.WriteLine("按q退出");
                message = Console.ReadLine();
                if (message != null && message.ToLower() == "q")
                {
                    MQConsumer.CloseConsumer();
                    break;
                }
            }
        }
    }
}
