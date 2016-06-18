using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using LogCleaner.Models;
using LogCleaner.Utils;
using LogCleaner.Windows;
using MessageBox = Xceed.Wpf.Toolkit.MessageBox;

namespace LogCleaner
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
        /// 添加清理目录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAddDir_OnClick(object sender, RoutedEventArgs e)
        {
            //添加清理目录
            System.Windows.Forms.FolderBrowserDialog dialog = new System.Windows.Forms.FolderBrowserDialog();
            System.Windows.Forms.DialogResult dialogResult = dialog.ShowDialog();
            if (dialogResult == System.Windows.Forms.DialogResult.OK || dialogResult == System.Windows.Forms.DialogResult.Yes)
            {
                //用户选中文件夹
                string dir = dialog.SelectedPath;
                if (string.IsNullOrWhiteSpace(dir))
                {
                    return;
                }

                if (CleanManager.IsManaged(dir))
                {
                    MessageBox.Show(string.Format("目录 {0} 已经被管理",dir), "提示", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }


                //进行处理
                ConfigWindow configWindow = new ConfigWindow(dir);

                if (configWindow.ShowDialog() == true)
                {
                    NLogHelper.Info(string.Format("目录 {0} 日志清理Job添加成功", dir));
                    //处理逻辑
                    MessageBox.Show(string.Format("目录 {0} 日志清理Job添加成功", dir), "提示", MessageBoxButton.OK, MessageBoxImage.Information);
                    RefreshUI();
                    return;
                }
            }

        }

        /// <summary>
        /// 删除清理目录
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
            //获取目录
            String directory = btn.Tag.ToString();
            if (CleanManager.DeleteCleanJob(directory))
            {
                NLogHelper.Info(string.Format("目录 {0} 日志清理Job删除成功", directory));
                //处理逻辑
                MessageBox.Show(string.Format("目录 {0} 日志清理Job删除成功", directory), "提示", MessageBoxButton.OK,
                    MessageBoxImage.Information);
                RefreshUI();
                return;
            }
            else
            {
                //处理逻辑
                MessageBox.Show(string.Format("目录 {0} 日志清理Job删除失败", directory), "提示", MessageBoxButton.OK,
                    MessageBoxImage.Information);
                RefreshUI();
                return;
            }
        }

        /// <summary>
        /// 关闭之前提示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainWindow_OnClosing(object sender, CancelEventArgs e)
        {
            if (MessageBox.Show("是否要关闭程序", "提示", MessageBoxButton.OKCancel) != MessageBoxResult.OK)
            {
                e.Cancel = true;
                return;
            }
        }
        
        /// <summary>
        /// 刷新UI list
        /// </summary>
        public static void Refresh()
        {
            Application.Current.Dispatcher.BeginInvoke(new Action(() =>
            {
                MainWindow window = Application.Current.MainWindow as MainWindow;
                if (window != null && window.IsLoaded)
                {
                    window.RefreshUI();
                }
            }));
        }
        
        /// <summary>
        /// 刷新
        /// </summary>
        public void RefreshUI()
        {
            List<CleanLog> cleanLogs = CleanManager.Snapshot();
            cleanLogs =
                cleanLogs.OrderBy(r=>r.CleanDir.CleanDetail.CleanMode.ToString()).ThenByDescending(r => r.LastCleanTime ?? DateTime.MinValue)
                    .ThenBy(r => r.CleanDir.ReserveDays)
                    .ToList();
            List<CleanViewModel> cleanViewModels = cleanLogs.Select(r => new CleanViewModel(r)).ToList();
            LvDetails.ItemsSource = cleanViewModels;
        }

        /// <summary>
        /// 加载后
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            RefreshUI();
            UpdateLogUi();
        }


        #region 日志相关

        /// <summary>
        /// 消息
        /// </summary>
        private static readonly ConcurrentQueue<string> MessageQueue = new ConcurrentQueue<string>();
        /// <summary>
        /// 消息最多多少
        /// </summary>
        private const int MessageCountLimit = 24;

        /// <summary>
        /// 上一次更新时间
        /// </summary>
        private static DateTime LastUiTime = DateTime.Now;

        public static void AddMsg(string msg)
        {
            if (string.IsNullOrEmpty(msg))
            {
                return;
            }

            if (MessageQueue.Count > MessageCountLimit)
            {
                string result = null;

                for (int i = 0; i < MessageCountLimit/4; i++)
                {
                    MessageQueue.TryDequeue(out result);
                }
            }

            msg = String.Format("{0}>>> {1}", DateTime.Now.ToString("yyyyMMdd HH:mm:ss"), msg);

            MessageQueue.Enqueue(msg);

            //最少三秒更新一次UI
            if ((DateTime.Now - LastUiTime).TotalSeconds > 3)
            {
                LastUiTime = DateTime.Now;
                Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                {
                    MainWindow window = Application.Current.MainWindow as MainWindow;
                    if (window != null && window.IsLoaded)
                    {
                        window.UpdateLogUi();
                    }
                }));
            }
        }

        /// <summary>
        /// updateui
        /// </summary>
        public void UpdateLogUi()
        {
            IEnumerator<string> enumerator = MessageQueue.GetEnumerator();
            StringBuilder sb = new StringBuilder();
            while (enumerator.MoveNext())
            {
                sb.AppendLine(enumerator.Current);
            }

            TbLog.Text = sb.ToString();
        }

        #endregion 
    }
}
