using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;

using NLog;
using ProcessMonitor.Models;
using Monitor = System.Threading.Monitor;

namespace ProcessMonitor.Utils
{
    public class TimerEx : IDisposable
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();
        /// <summary>
        /// 定时器
        /// </summary>
        private Timer _timer = null;

        /// <summary>
        /// 锁
        /// </summary>
        private object _locker = new object();

        /// <summary>
        /// 定时器是否开启
        /// 这里并不是指的是定时器是否真的启动，而是定时器的功能是否启动
        /// </summary>
        private bool _isStarted = false;

        /// <summary>
        /// 是否回调在运行
        /// </summary>
        private bool _isRunning = false;

        /// <summary>
        /// 定时器是否开启
        /// 这里并不是指的是定时器是否真的启动，而是定时器的功能是否启动
        /// </summary>
        public bool IsStarted
        {
            get
            {
                lock (_locker)
                {
                    return _isStarted;
                }
            }
            set
            {
                lock (_locker)
                {
                    _isStarted = value;
                }
            }
        }

        /// <summary>
        /// 是否回调在运行
        /// </summary>
        public bool IsRunning
        {
            get
            {
                lock (_locker)
                {
                    return _isRunning;
                }
            }
           
        }


        /// <summary>
        /// 构造函数
        /// </summary>
        public TimerEx()
        {
            _timer = new Timer(new TimerCallback(TimerCallback), null, 1500, 9000);
        }

        /// <summary>
        /// 开始运行
        /// </summary>
        public void Start()
        {
            IsStarted = true;
        }

        /// <summary>
        /// 结束运行
        /// </summary>
        public void Stop()
        {
            IsStarted = false;
        }

        /// <summary>
        /// 定时器回调函数
        /// </summary>
        /// <param name="state"></param>
        private void TimerCallback(object state)
        {
            //如果未启动，直接退出
            if (!IsStarted)
            {
                return;
            }

            lock (_locker)
            {
                if (_isRunning)
                {
                    //回调正在运行
                    return;
                }
                _isRunning = true;
            }

            try
            {
                CallBack(state);
            }
            catch (Exception ex)
            {
                _logger.Error("定时器回调函数发生异常：" + ex);
                MainWindow.AddMsg("定时器回调函数发生异常：" + ex);
            }
            finally
            {
                lock (_locker)
                {
                    _isRunning = false;
                }
            }
        }

        /// <summary>
        /// 实际的回调函数
        /// </summary>
        /// <param name="state"></param>
        public static void CallBack(object state)
        {
            IEnumerator<MonitorProcess> enumerator = App.MonitorProcesses.GetEnumerator();
            List<MonitorProcess> processes = new List<MonitorProcess>();
            while (enumerator.MoveNext())
            {
                processes.Add(enumerator.Current);
            }

            if (processes.Count <= 0)
            {
                _logger.Info("没有要监视的进程");
                MainWindow.AddMsg("没有要监视的进程");
                Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                {
                    MainWindow window = Application.Current.MainWindow as MainWindow;
                    if (window != null && window.IsInitialized)
                    {
                        window.Refresh(new List<MonitorDto>());
                    }
                }));
                return;
            }
            Process[] processArr = Process.GetProcesses();
            foreach (var item in processes)
            {
                string fileName = item.FileName;
                List<Tuple<string, Process>> fileNameList = new List<Tuple<string, Process>>();
                List<Tuple<string, Process>> programNameList = new List<Tuple<string, Process>>();
                foreach (var processitem in processArr)
                {
                    try
                    {
                        string programName = processitem.ProcessName;
                        programNameList.Add(new Tuple<string, Process>(programName,processitem));
                    }
                    catch (Exception)
                    {
                        
                    }
                    try
                    {
                        fileNameList.Add(new Tuple<string, Process>( processitem.MainModule.FileName,processitem));
                    }
                    catch (Exception)
                    {

                    }
                }
                //获取重复的fileName
                var resultList = fileNameList.Where(r => StringUtils.EqualsEx(fileName, r.Item1)).ToList();
                var resultProgramNameList =
                    programNameList.Where(r => StringUtils.EqualsEx(Path.GetFileNameWithoutExtension(fileName), r.Item1)||StringUtils.EqualsEx(Path.GetFileName(fileName),r.Item1))
                        .ToList();
                if (resultList.Count <= 0 && resultProgramNameList.Count<=0)
                {
                    //需要重启
                    if ((item.RestartTime.HasValue && (DateTime.Now - item.RestartTime.Value).TotalMinutes > 1) || !item.RestartTime.HasValue)
                    {
                        //连续重启的间隔不得少于1分钟
                        item.ProcessCount = resultList.Count;
                        item.ScannerTime = DateTime.Now;
                        item.RestartTime = DateTime.Now;
                        item.RestartedCount++;
                        RunProgramNormal(item.FileName);
                    }
                    else
                    {
                        string msg = String.Format("{0}上次重启时间为{1},重启时间较近，暂不重启", item.FileName,
                            item.RestartTime.Value.ToString("yyyyMMdd HH:mm:ss"));
                        _logger.Warn(msg);
                        MainWindow.AddMsg(msg);
                        item.ProcessCount = resultList.Count;
                        item.ScannerTime = DateTime.Now;
                    }
                }
                else
                {
                    item.ProcessCount = Math.Max(resultList.Count,resultProgramNameList.Count);
                    item.ScannerTime = DateTime.Now;
                    if (resultList.Count > 0)
                    {
                        item.MainWindowTitle = resultList[0].Item2.MainWindowTitle;
                        item.ProgramName = resultList[0].Item2.ProcessName;
                    }
                    else if (resultProgramNameList.Count > 0)
                    {
                        item.MainWindowTitle = resultProgramNameList[0].Item2.MainWindowTitle;
                        item.ProgramName = resultProgramNameList[0].Item2.ProcessName;
                    }
                    
                }
            }
            List<MonitorDto> dtos = new List<MonitorDto>();
            foreach (var item in processes)
            {
                MonitorDto dto = new MonitorDto();
                dto.FileName = item.FileName;
                dto.ProgramName = item.ProgramName;
                dto.MainWindowTitle = item.MainWindowTitle;
                dto.ProcessCount = item.ProcessCount;
                dto.RebootCount = item.RestartedCount;
                dto.ScannerTime = item.ScannerTime.HasValue?item.ScannerTime.Value.ToString("MMdd HH:mm:ss"):"";
                dto.RebootTime = item.RestartTime.HasValue ? item.RestartTime.Value.ToString("MMdd HH:mm:ss") : "";
                dtos.Add(dto);
            }
            dtos = dtos.OrderByDescending(r => r.ProcessCount).ThenByDescending(r=>r.RebootCount).ToList();
            _logger.Info(String.Format("监视{0}个程序，刷新界面",dtos.Count));
            MainWindow.AddMsg(String.Format("监视{0}个程序，刷新界面", dtos.Count));

            Application.Current.Dispatcher.BeginInvoke(new Action(() =>
            {
                MainWindow window =  Application.Current.MainWindow as MainWindow;
                if (window != null && window.IsInitialized)
                {
                    window.Refresh(dtos);
                }
            }));
        }

        /// <summary>
        /// 运行指定的程序
        /// </summary>
        /// <param name="programName">程序名的全限定路径名</param>
        /// <param name="args">程序的参数</param>
        public static Process RunProgramNormal(String programName, String args = null)
        {
            try
            {
                if (!File.Exists(programName))
                {
                    _logger.Error("未找到文件:"+programName);
                    return null;
                }
                if (string.IsNullOrWhiteSpace(args))
                {
                    return Process.Start(programName);
                }
                else
                {
                    return Process.Start(programName, args);
                }
            }
            catch (Exception e)
            {
                _logger.Error("启动程序{0}异常：{1}",programName,e);
                return null;
            }
        }

        /// <summary>
        /// 释放资源
        /// </summary>
        public void Dispose()
        {
            if (_timer != null)
            {
                _timer.Dispose();
            }
        }
    }

}
