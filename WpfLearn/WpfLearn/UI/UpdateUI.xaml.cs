using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WpfLearn.UI
{
    /// <summary>
    /// UpdateUI.xaml 的交互逻辑
    /// </summary>
    public partial class UpdateUI : Window
    {
        public UpdateUI()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 定时器
        /// </summary>
        private Timer timer;
        private void UpdateUI_OnInitialized(object sender, EventArgs e)
        {
            timer = new Timer(new TimerCallback((obj) =>
            {
                Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                {
                    UpdateUI window =  Application.Current.MainWindow as UpdateUI;
                    if (window != null&&window.IsInitialized)
                    {
                        window.Update(DateTime.Now);
                    }
                }), DispatcherPriority.Normal ,null);
            }),null,1000,900);
            
        }

        /// <summary>
        /// 在UI线程上执行的更新UI操作
        /// </summary>
        /// <param name="dateTime"></param>
        private void Update(DateTime dateTime)
        {
            TbInfo.Text = dateTime.ToString("yyyy-MM-dd HH:mm:ss");
        }

        private void UpdateUI_OnClosed(object sender, EventArgs e)
        {
            if (timer != null)
            {
                timer.Dispose();
            }
        }
    }
}
