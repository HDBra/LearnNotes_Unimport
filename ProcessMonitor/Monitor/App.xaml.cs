using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using NLog;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using ProcessMonitor.Models;
using ProcessMonitor.Utils;

namespace ProcessMonitor
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        private Logger _logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// 定时器
        /// </summary>
        private static TimerEx _timer = new TimerEx();
        /// <summary>
        /// 储存的xml文件名
        /// </summary>
        public const string XmlFileName = "monitor.xml";

        /// <summary>
        /// Monitor的详细资料
        /// </summary>
        public static ConcurrentQueue<MonitorProcess> MonitorProcesses = new ConcurrentQueue<MonitorProcess>();

        /// <summary>
        /// 程序异常
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void App_OnDispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            e.Handled = true;
            Exception ex = e.Exception;
            _logger.Warn("UI县城捕获未处理异常："+ex);
        }

        /// <summary>
        /// 程序退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void App_OnExit(object sender, ExitEventArgs e)
        {
            _logger.Trace("程序退出");
            _timer.Dispose();
            Environment.Exit(0);
        }

        /// <summary>
        /// 程序启动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void App_OnStartup(object sender, StartupEventArgs e)
        {
            _logger.Trace("程序启动");
            _timer.Start();
            ProcessMonitor.MainWindow.AddMsg("程序启动");
            Process[] runningProcesses = Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName);

            if (runningProcesses.Length > 1)
            {
                _logger.Info("多个进程启动，退出当前程序");
                MessageBox.Show("已经有一个程序启动，点击退出");
                Environment.Exit(-1);
                return;
            }

            _logger.Info("开始加载配置文件");
            List<string> processNames = new List<string>();
            if (File.Exists(XmlFileName))
            {
                
                try
                {
                    processNames = SeralizerHelper.ToObject<List<string>>(XmlFileName);
                    _logger.Info("加载配置文件成功");
                    ProcessMonitor.MainWindow.AddMsg("加载配置文件成功");
                }
                catch (Exception ex)
                {
                    _logger.Info("加载配置文件失败："+ex);
                    ProcessMonitor.MainWindow.AddMsg("加载配置文件失败：" + ex);
                }
            }

            
            if (processNames != null)
            {
                foreach (var name in processNames)
                {
                    MonitorProcess monitorProcess = new MonitorProcess();
                    monitorProcess.FileName = name;
                    MonitorProcesses.Enqueue(monitorProcess);
                }
            }
        }

    }
}
