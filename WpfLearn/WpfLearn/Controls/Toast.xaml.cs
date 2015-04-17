using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using Xceed.Wpf.Toolkit.Core.Converters;

namespace WpfLearn.Controls
{
    /// <summary>
    /// Toast.xaml 的交互逻辑
    /// </summary>
    public partial class Toast : Window
    {
        private string message;
        private Timer timer;
        public Toast(string msg)
        {
            this.message = msg;
     
            InitializeComponent();
        }

        public static void Show(string msg)
        {
            Toast toast = new Toast(msg);
            toast.Show();
        }
        
        private void Toast_OnInitialized(object sender, EventArgs e)
        {
            LbTip.Content = message;
            timer = new Timer(2000);
            timer.Elapsed += (tsender, args) =>
            {
                timer.Stop();
                timer.Close();
                Dispatcher.Invoke(DispatcherPriority.Normal, (Action) Close);
            };
            timer.Start();
        }
    }
}
