using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DemoBrowser.Utils;

namespace DemoBrowser
{
    static class Program
    {
        private static TimerEx _timer = new TimerEx();
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            NLogHelper.Info("应用程序启动");
            _timer.Start();
            //设置处理异常模式
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            //捕获ui异常
            Application.ThreadException  += new ThreadExceptionEventHandler(Appication_UI_Exception);
            //处理非UI线程异常
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
            NLogHelper.Info("应用程序退出");
            _timer.Dispose();
            MQConsumer.CloseConsumer();
            //关闭程序
            Environment.Exit(0);
        }

        /// <summary>
        /// 处理非ui线程异常
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            NLogHelper.Error("应用程序非UI线程异常:"+e.ExceptionObject);
        }

        /// <summary>
        /// 处理ui线程异常
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void Appication_UI_Exception(object sender, ThreadExceptionEventArgs e)
        {
            NLogHelper.Error("应用程序UI线程异常:"+e.Exception);
        }
    }
}
