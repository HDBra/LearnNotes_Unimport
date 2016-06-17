using System;
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
                    //处理逻辑
                    MessageBox.Show(string.Format("目录 {0} 日志清理添加成功", dir), "提示", MessageBoxButton.OK, MessageBoxImage.Information);
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
               
        }
    }
}
