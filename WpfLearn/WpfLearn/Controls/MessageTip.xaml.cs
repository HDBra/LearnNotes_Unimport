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

namespace WpfLearn.Controls
{
    /// <summary>
    /// MessageTip.xaml 的交互逻辑
    /// </summary>
    public partial class MessageTip : Window
    {
        private string title, message;

        public MessageTip()
        {
            InitializeComponent();
        }
        public MessageTip(string title, string message)
        {
            InitializeComponent();
            this.title = title;
            this.message = message;
            this.Title = title ?? string.Empty;
            TbMsg.Text = message;
        }

        public static bool? ShowDialog(string title, string message)
        {
            MessageTip window = new MessageTip(title, message);
            return window.ShowDialog();
        }

        private void Ok_OnClick(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void Cancel_OnClick(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
