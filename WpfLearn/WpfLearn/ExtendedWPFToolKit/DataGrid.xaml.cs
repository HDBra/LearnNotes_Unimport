using System;
using System.Collections.Generic;
using System.Data;
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
using Xceed.Wpf.DataGrid;

namespace WpfLearn.ExtendedWPFToolKit
{
    /// <summary>
    /// DataGrid.xaml 的交互逻辑
    /// </summary>
    public partial class DataGrid : Window
    {
        public DataGrid()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 初始化方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGrid_OnInitialized(object sender, EventArgs e)
        {
            List<Order> orders = new List<Order>
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


            DataGridCollectionView collectionView = new DataGridCollectionView(orders);
            //collectionView.GroupDescriptions.Add(new DataGridGroupDescription("Name"));
      
            DataGrid01.ItemsSource = collectionView;
        }
    }

    public class Order
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        public DateTime CreatedTime { get; set; }
    }
}
