using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
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

namespace WpfLearn.Events
{
    /// <summary>
    /// DragDrop.xaml 的交互逻辑
    /// </summary>
    public partial class DragDrop : Window
    {
        public DragDrop()
        {
            InitializeComponent();
        }

        private void DragStart(object sender, MouseButtonEventArgs mouseButtonEventArgs)
        {
            if(!string.IsNullOrWhiteSpace(TxtSorce.Text))
            System.Windows.DragDrop.DoDragDrop(TxtSorce, TxtSorce.Text, DragDropEffects.Copy);
        }

        private void LblTarget_OnDrop(object sender, DragEventArgs e)
        {
            LblTarget.Content = e.Data.GetData(DataFormats.Text);
        }
    }
}
