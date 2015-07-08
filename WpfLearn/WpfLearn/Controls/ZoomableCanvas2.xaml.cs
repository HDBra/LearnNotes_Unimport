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
    /// ZoomableCanvas2.xaml 的交互逻辑
    /// </summary>
    public partial class ZoomableCanvas2 : Window
    {
        public ZoomableCanvas2()
        {
            InitializeComponent();
        }

        private void Button01_OnClick(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("images/airport.jpg",UriKind.Relative);
            BitmapImage image = new BitmapImage(uri);
            ImageBrush brush = new ImageBrush();
            brush.ImageSource = image;
            CustomCanvas.Background = brush;
        }

        private void Button02_OnClick(object sender, RoutedEventArgs e)
        {
            CustomCanvas.Background = null;
        }
    }
}
