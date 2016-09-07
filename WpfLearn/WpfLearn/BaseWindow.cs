using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace WpfLearn
{
    /// <summary>
    /// wpf基类Window
    /// </summary>
    public class BaseWindow:Window
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public BaseWindow()
        {

        }

        /// <summary>
        /// 多线程执行
        /// </summary>
        /// <param name="uiAction">回调到ui线程的内容</param>
        public void SafeDispatch(Action uiAction)
        {
            //立刻返回，同时把action放到dispatcher的队列中
            //invoke是等待action在dispatcher队列中执行完毕后返回
            Dispatcher.BeginInvoke(new Action(() =>
            {
                if (this.IsLoaded && uiAction!=null)
                {
                    uiAction();
                }
            }),DispatcherPriority.Normal);
        }

        /// <summary>
        /// 在多线程中执行一个action
        /// </summary>
        /// <param name="nonUiAction"></param>
        public void RunTask(Action nonUiAction)
        {
            Task.Factory.StartNew(() =>
            {
                if (nonUiAction != null)
                {
                    nonUiAction();
                }
            });
        }

    }
}
