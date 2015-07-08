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
using WpfLearn.ExtendedWPFToolKit;

namespace WpfLearn.Controls
{
    /// <summary>
    /// ExtendedDataGrid02.xaml 的交互逻辑
    /// </summary>
    public partial class ExtendedDataGrid02 : Window
    {
        public ExtendedDataGrid02()
        {
            InitializeComponent();
        }

        private void ExtendedDataGrid02_OnInitialized(object sender, EventArgs e)
        {
            DataGrid01.ItemsSource = orders;
        }



        private List<Order> orders = new List<Order>
            {
                new Order() {Id = Guid.NewGuid(), Name = "apple", Price = 0.8, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple", Price = 0.8, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple2", Price = 0.82, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple3", Price = 0.83, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple4", Price = 0.84, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple5", Price = 0.85, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple6", Price = 0.86, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple7", Price = 0.87, CreatedTime = DateTime.Now},
                    new Order() {Id = Guid.NewGuid(), Name = "apple", Price = 0.8, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple", Price = 0.8, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple2", Price = 0.82, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple3", Price = 0.83, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple4", Price = 0.84, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple5", Price = 0.85, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple6", Price = 0.86, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple7", Price = 0.87, CreatedTime = DateTime.Now},
                    new Order() {Id = Guid.NewGuid(), Name = "apple", Price = 0.8, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple", Price = 0.8, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple2", Price = 0.82, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple3", Price = 0.83, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple4", Price = 0.84, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple5", Price = 0.85, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple6", Price = 0.86, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple7", Price = 0.87, CreatedTime = DateTime.Now},
                    new Order() {Id = Guid.NewGuid(), Name = "apple", Price = 0.8, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple", Price = 0.8, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple2", Price = 0.82, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple3", Price = 0.83, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple4", Price = 0.84, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple5", Price = 0.85, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple6", Price = 0.86, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple7", Price = 0.87, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple", Price = 0.8, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple", Price = 0.8, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple2", Price = 0.82, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple3", Price = 0.83, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple4", Price = 0.84, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple5", Price = 0.85, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple6", Price = 0.86, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple7", Price = 0.87, CreatedTime = DateTime.Now},
                    new Order() {Id = Guid.NewGuid(), Name = "apple", Price = 0.8, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple", Price = 0.8, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple2", Price = 0.82, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple3", Price = 0.83, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple4", Price = 0.84, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple5", Price = 0.85, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple6", Price = 0.86, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple7", Price = 0.87, CreatedTime = DateTime.Now},
                    new Order() {Id = Guid.NewGuid(), Name = "apple", Price = 0.8, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple", Price = 0.8, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple2", Price = 0.82, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple3", Price = 0.83, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple4", Price = 0.84, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple5", Price = 0.85, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple6", Price = 0.86, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple7", Price = 0.87, CreatedTime = DateTime.Now},
                    new Order() {Id = Guid.NewGuid(), Name = "apple", Price = 0.8, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple", Price = 0.8, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple2", Price = 0.82, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple3", Price = 0.83, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple4", Price = 0.84, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple5", Price = 0.85, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple6", Price = 0.86, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple7", Price = 0.87, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple", Price = 0.8, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple", Price = 0.8, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple2", Price = 0.82, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple3", Price = 0.83, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple4", Price = 0.84, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple5", Price = 0.85, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple6", Price = 0.86, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple7", Price = 0.87, CreatedTime = DateTime.Now},
                    new Order() {Id = Guid.NewGuid(), Name = "apple", Price = 0.8, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple", Price = 0.8, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple2", Price = 0.82, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple3", Price = 0.83, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple4", Price = 0.84, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple5", Price = 0.85, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple6", Price = 0.86, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple7", Price = 0.87, CreatedTime = DateTime.Now},
                    new Order() {Id = Guid.NewGuid(), Name = "apple", Price = 0.8, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple", Price = 0.8, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple2", Price = 0.82, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple3", Price = 0.83, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple4", Price = 0.84, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple5", Price = 0.85, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple6", Price = 0.86, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple7", Price = 0.87, CreatedTime = DateTime.Now},
                    new Order() {Id = Guid.NewGuid(), Name = "apple", Price = 0.8, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple", Price = 0.8, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple2", Price = 0.82, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple3", Price = 0.83, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple4", Price = 0.84, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple5", Price = 0.85, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple6", Price = 0.86, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple7", Price = 0.87, CreatedTime = DateTime.Now},
            };
    }
}
