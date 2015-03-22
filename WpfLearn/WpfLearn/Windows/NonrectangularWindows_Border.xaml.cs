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

namespace WpfLearn.Windows
{
    /// <summary>
    /// NonrectangularWindows_Border.xaml 的交互逻辑
    /// </summary>
    public partial class NonrectangularWindows_Border : Window
    {
        public NonrectangularWindows_Border()
        {
            InitializeComponent();
        }

        private bool isWiden = true;
        private void UIElement_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            isWiden = true;
        }

        private void UIElement_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            isWiden = false;


            Rectangle rect = (Rectangle)sender;
            rect.ReleaseMouseCapture();
        }

        private void UIElement_OnMouseMove(object sender, MouseEventArgs e)
        {
            Rectangle rect = (Rectangle)sender;
            if (isWiden)
            {
                rect.CaptureMouse();
                double newWidth = e.GetPosition(this).X + 5;
                if (newWidth > 0) this.Width = newWidth;
            }
        }
    }
}
