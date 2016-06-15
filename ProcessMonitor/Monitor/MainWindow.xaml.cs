using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using ProcessMonitor.Models;
using ProcessMonitor.Utils;

namespace ProcessMonitor
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 添加监控程序按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Add_Monitor_OnClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "应用程序|*.exe|所有文件|*";
            if (dialog.ShowDialog() == true)
            {
                string fileName = dialog.FileName;
                if (string.IsNullOrWhiteSpace(fileName))
                {
                    return;
                }
                IEnumerator<MonitorProcess> enumerator =  App.MonitorProcesses.GetEnumerator();
                List<String> fileList = new List<string>();
                while (enumerator.MoveNext())
                {
                    string current = enumerator.Current.FileName;
                    if (string.IsNullOrWhiteSpace(current))
                    {
                        continue;
                    }
                    //去掉重复
                    if (fileList.Any(r => StringUtils.EqualsEx(r, current)))
                    {
                        continue;
                    }
                    fileList.Add(current);
                }

                if (!fileList.Any(r => StringUtils.EqualsEx(r, fileName)))
                {
                    fileList.Add(fileName);
                    MonitorProcess monitorProcess = new MonitorProcess();
                    monitorProcess.FileName = fileName;
                    App.MonitorProcesses.Enqueue(monitorProcess);
                }

                SeralizerHelper.ToFile(fileList,App.XmlFileName);
            }


        }

        /// <summary>
        /// 删除处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Delete_OnClick(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            if (btn == null)
            {
                return;
            }
            string fileName = btn.Tag.ToString();
            if (string.IsNullOrWhiteSpace(fileName))
            {
                return;
            }

            if (
                MessageBox.Show(String.Format("是否不再监控程序{0}{1}", Environment.NewLine, fileName), "警示",
                    MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                IEnumerator<MonitorProcess> enumerator = App.MonitorProcesses.GetEnumerator();
                List<String> fileList = new List<string>();
                List<MonitorProcess> removeList = new List<MonitorProcess>();
                while (enumerator.MoveNext())
                {
                    string current = enumerator.Current.FileName;
                    if (string.IsNullOrWhiteSpace(current))
                    {
                        continue;
                    }
                    //去掉重复
                    if (fileList.Any(r => StringUtils.EqualsEx(r, current)))
                    {
                        continue;
                    }
                    fileList.Add(current);
                    
                    if (StringUtils.EqualsEx(current, fileName))
                    {
                        removeList.Add(enumerator.Current);
                    }
                }

                fileList.RemoveAll(s => StringUtils.EqualsEx(s, fileName));
              
                int count = App.MonitorProcesses.Count;
                if (removeList.Count > 0)
                {
                    for (int i = 0; i < count; i++)
                    {
                        MonitorProcess temp = null;
                        if (App.MonitorProcesses.TryDequeue(out temp))
                        {
                            if (removeList.All(r => r != temp))
                            {
                                App.MonitorProcesses.Enqueue(temp);
                            } 
                        }
                    }
                }

                SeralizerHelper.ToFile(fileList, App.XmlFileName);
            }
        }

        public void BringToFornt()
        {
            this.Visibility = Visibility.Visible;
            this.Activate();
        }

        #region 日志相关
        /// <summary>
        /// 最大显示的消息，防止内存泄漏
        /// </summary>
        private const int MaxMsgCount = 36;
        //保存消息
        private static ConcurrentQueue<string> Msgs = new ConcurrentQueue<string>(); 

        /// <summary>
        /// 上一次因为消息更新ui的时间
        /// </summary>
        private static DateTime LastUITime =  DateTime.Now;

        public static void AddMsg(String msg)
        {
            if (string.IsNullOrEmpty(msg))
            {
                return;
            }
            msg = String.Format("{0}>>> {1}", DateTime.Now.ToString("yyyyMMdd HH:mm:ss"), msg);
            if (Msgs.Count >= MaxMsgCount)
            {
                string temp;
                Msgs.TryDequeue(out temp);
                Msgs.TryDequeue(out temp);
                Msgs.TryDequeue(out temp);
                Msgs.TryDequeue(out temp);
                Msgs.TryDequeue(out temp);
                Msgs.TryDequeue(out temp);
                Msgs.TryDequeue(out temp);
                Msgs.TryDequeue(out temp);
            }

            Msgs.Enqueue(msg);

            if ((DateTime.Now - LastUITime).TotalSeconds > 2)
            {
                LastUITime = DateTime.Now;
                //更新ui
                Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                {
                    MainWindow window = Application.Current.MainWindow as MainWindow;
                    if (window != null && window.IsInitialized)
                    {
                        IEnumerator<string> enumerator = Msgs.GetEnumerator();
                        StringBuilder sb = new StringBuilder();
                        while (enumerator.MoveNext())
                        {
                            sb.AppendLine(enumerator.Current);
                        }

                        window.ShowMsg(sb.ToString());
                    }
                }));
            }
        }

        public void ShowMsg(String msg)
        {
            if (!String.IsNullOrEmpty(msg))
            {
                TbLog.Text = msg;
            }
        }

        #endregion

        /// <summary>
        /// 刷新界面
        /// </summary>
        /// <param name="dtos"></param>
        internal void Refresh(List<MonitorDto> dtos)
        {
            if (IsInitialized)
            {
                LvDetails.ItemsSource = dtos;
            }
        }
    }
}
