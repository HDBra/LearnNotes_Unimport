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

namespace WpfLearn.Bindings.Db
{
    /// <summary>
    /// ObjectBingding.xaml 的交互逻辑
    /// </summary>
    public partial class ObjectBingding : Window
    {
        public ObjectBingding()
        {
            InitializeComponent();
        }

        private void ObjectBingding_OnInitialized(object sender, EventArgs e)
        {
            GridProduct.DataContext = new Product("module1","modulename",12,null);
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            Product product = (Product)GridProduct.DataContext;
            product.Description = "Hello world";
        }
    }
}
