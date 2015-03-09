using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace WpfLearn
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// 在应用程序开始时执行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void App_OnStartup(object sender, StartupEventArgs e)
        {
            //命令行参数
            String[] args = e.Args;
        }

        /// <summary>
        /// 应用程序退出时执行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void App_OnExit(object sender, ExitEventArgs e)
        {
            //
        }

        /// <summary>
        /// 当某个窗口激活的时候执行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void App_OnActivated(object sender, EventArgs e)
        {
            //
        }
        /// <summary>
        /// 窗口变为不激活时执行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void App_OnDeactivated(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// UI 线程所有未被处理的异常
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void App_OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            //将其置为true，如果程序仍然是有效状态并且能够继续执行时
            e.Handled = true;
        }

        /// <summary>
        /// 当用户在注销或关闭操作系统关闭 Windows 会话发送
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void App_OnSessionEnding(object sender, SessionEndingCancelEventArgs e)
        {
            //当用户在注销或关闭操作系统关闭 Windows 会话
        }


        #region EventSetters

        /// <summary>
        /// 鼠标进入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBolck_OnMouseEnter(object sender, MouseEventArgs e)
        {
            if (sender is TextBlock)
            {
                TextBlock tb = sender as TextBlock;
                tb.Background = new SolidColorBrush(Colors.LightGoldenrodYellow);
            }
        }

        private void TextBolck_OnMouseLeave(object sender, MouseEventArgs e)
        {
            if (sender is TextBlock)
            {
                TextBlock tb = sender as TextBlock;
                tb.Background = null;
            }
        }

        #endregion


    }
}
