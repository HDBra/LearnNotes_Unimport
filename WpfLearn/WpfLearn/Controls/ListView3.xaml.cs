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
using WpfLearn.Deletable;

namespace WpfLearn.Controls
{
    /// <summary>
    /// ListView3.xaml 的交互逻辑
    /// </summary>
    public partial class ListView3 : Window
    {
        public ListView3()
        {
            InitializeComponent();
        }

        private void ListView3_OnLoaded(object sender, RoutedEventArgs e)
        {
            LstProducts.ItemsSource = Product.GetProducts();
            LstProducts.View = (ViewBase)FindResource("ImageDetailTileView");
            LstProducts.ItemContainerStyle = (Style)FindResource("TileItemStyle");

            LstProducts.View = (ViewBase)FindResource("GridViewRes");
            LstProducts.ItemContainerStyle = (Style)FindResource("GridViewItemStyle");

            ////////////////////////////////////////////////
            //LstProducts.View = new TileView();
            //LstProducts.View = new GridView();
        }

        private void EventSetter_OnHandler(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(sender.GetType().ToString()+e.RoutedEvent);
        }

    }
}
