using System;
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
using System.Windows.Shapes;
using Xceed.Wpf.Toolkit.Core;

namespace LogCleaner.Windows
{
    /// <summary>
    /// ConfigWindow.xaml 的交互逻辑
    /// </summary>
    public partial class ConfigWindow : Window
    {
        private string Directory { get; set; }
        
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dir"></param>
        public ConfigWindow(string dir)
        {
            Directory = dir;
            InitializeComponent();
        }

        /// <summary>
        /// 配置完成相应
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConfigWizard_OnFinish(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// 当进入第二个页面时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SecondPage_OnEnter(object sender, RoutedEventArgs e)
        {
            if (RadioByDay.IsChecked == true)
            {
                GbMonth.Visibility = Visibility.Collapsed;
                GbWeek.Visibility = Visibility.Collapsed;
            }

            if (RadioByMonth.IsChecked == true)
            {
                GbMonth.Visibility = Visibility.Visible;
                GbWeek.Visibility = Visibility.Collapsed;
            }

            if (RadioByWeek.IsChecked == true)
            {
                GbMonth.Visibility = Visibility.Collapsed;
                GbWeek.Visibility = Visibility.Visible;
            }
        }
    }
}
