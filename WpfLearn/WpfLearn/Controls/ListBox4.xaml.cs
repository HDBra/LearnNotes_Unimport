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
    /// ListBox4.xaml 的交互逻辑
    /// </summary>
    public partial class ListBox4 : Window
    {
        public ListBox4()
        {
            InitializeComponent();
        }

        private void OnInitialized(object sender, EventArgs e)
        {
            List<Product> products = new List<Product>();
            products.Add(new Product("1","Tools",10,"desc"));
            products.Add(new Product("1", "ModelName111", 10, "desc"));
            products.Add(new Product("1", "ModelName111", 10, "desc"));
            LstProducts.ItemsSource = products;
        }
    }
}
