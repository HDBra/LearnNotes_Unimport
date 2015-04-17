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

namespace WpfLearn.Controls
{
    /// <summary>
    /// ZoomableCanvas.xaml 的交互逻辑
    /// </summary>
    public partial class ZoomableCanvas : Window
    {
        public ZoomableCanvas()
        {
            InitializeComponent();
        }

        private void OffsetVar_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            LocalCanvas.Offset = new Point(offsetVar.Value,0);
            
        }

        private string s;
        private void ZoomableCanvas_OnInitialized(object sender, EventArgs e)
        {
            Uri uri = new Uri("images/airport.jpg", UriKind.Relative);
            ImageBrush brush = new ImageBrush();

            BitmapImage image = new BitmapImage(uri);
            while (image.IsDownloading)
            {
                Thread.Sleep(1);
            }

            brush.ImageSource = image;
            LocalCanvas.Background = brush;
            LocalCanvas.Width = image.PixelWidth;
            LocalCanvas.Height = image.PixelHeight;
            LocalCanvas.Scale = 1;
            LocalCanvas.ApplyTransform = true;
            LocalCanvas.Offset = new Point(0,0);
            s = image.PixelWidth + ":" + image.PixelHeight;
        }

        private void LocalCanvas_OnMouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (e.Delta > 0)
            {
                LocalCanvas.Scale = LocalCanvas.Scale*(1 + 0.1);
            }
            else
            {
                LocalCanvas.Scale = LocalCanvas.Scale * (1 - 0.1);
            }
        }

        private void LocalCanvas_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ismove = true;
        }

        private void LocalCanvas_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ismove = false;
        }

        private bool ismove = false;
        private void LocalCanvas_OnMouseMove(object sender, MouseEventArgs e)
        {
            if (!ismove)
            {
                return;
            }
        }
    }
}
