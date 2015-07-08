using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using WpfLearn.Utils;
using DataGridCellEditEndingEventArgs = ExtendedGrid.Microsoft.Windows.Controls.DataGridCellEditEndingEventArgs;
using DataGridRowEditEndingEventArgs = ExtendedGrid.Microsoft.Windows.Controls.DataGridRowEditEndingEventArgs;
using SelectedCellsChangedEventArgs = ExtendedGrid.Microsoft.Windows.Controls.SelectedCellsChangedEventArgs;

namespace WpfLearn.Controls
{
    /// <summary>
    /// ExtendedDataGrid.xaml 的交互逻辑
    /// </summary>
    public partial class ExtendedDataGrid01 : Window
    {
        public ExtendedDataGrid01()
        {
            InitializeComponent();
        }

        private void ExtendedDataGrid01_OnInitialized(object sender, EventArgs e)
        {
            List<Order> orders = new List<Order>
            {
                new Order() {Id = Guid.NewGuid(), Name = "apple11", Price = 0.8, CreatedTime = DateTime.Now,IsChecked = true},
                new Order() {Id = Guid.NewGuid(), Name = "apple", Price = 0.8, CreatedTime = DateTime.Now,IsChecked = true},
                new Order() {Id = Guid.NewGuid(), Name = "orange2", Price = 0.82, CreatedTime = DateTime.Now,IsChecked = true},
                new Order() {Id = Guid.NewGuid(), Name = "apple3", Price = 0.83, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple4", Price = 0.84, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple5", Price = 0.85, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple6", Price = 0.86, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple7", Price = 0.87, CreatedTime = DateTime.Now},
                    new Order() {Id = Guid.NewGuid(), Name = "apple", Price = 0.8, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple", Price = 0.8, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "orange2", Price = 0.82, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple3", Price = 0.83, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple4", Price = 0.84, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple5", Price = 0.85, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple6", Price = 0.86, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple7", Price = 0.87, CreatedTime = DateTime.Now},
                    new Order() {Id = Guid.NewGuid(), Name = "apple", Price = 0.8, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple", Price = 0.8, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "orange2", Price = 0.82, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple3", Price = 0.83, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple4", Price = 0.84, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple5", Price = 0.85, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple6", Price = 0.86, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple7", Price = 0.87, CreatedTime = DateTime.Now},
                    new Order() {Id = Guid.NewGuid(), Name = "apple", Price = 0.8, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple", Price = 0.8, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "orange2", Price = 0.82, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple3", Price = 0.83, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple4", Price = 0.84, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple5", Price = 0.85, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple6", Price = 0.86, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple7", Price = 0.87, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple", Price = 0.8, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple", Price = 0.8, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "orange2", Price = 0.82, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple3", Price = 0.83, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple4", Price = 0.84, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple5", Price = 0.85, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple6", Price = 0.86, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple7", Price = 0.87, CreatedTime = DateTime.Now},
                    new Order() {Id = Guid.NewGuid(), Name = "apple", Price = 0.8, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple", Price = 0.8, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "orange2", Price = 0.82, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple3", Price = 0.83, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple4", Price = 0.84, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple5", Price = 0.85, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple6", Price = 0.86, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple7", Price = 0.87, CreatedTime = DateTime.Now},
                    new Order() {Id = Guid.NewGuid(), Name = "apple", Price = 0.8, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple", Price = 0.8, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "orange2", Price = 0.82, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple3", Price = 0.83, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple4", Price = 0.84, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple5", Price = 0.85, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple6", Price = 0.86, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple7", Price = 0.87, CreatedTime = DateTime.Now},
                    new Order() {Id = Guid.NewGuid(), Name = "apple", Price = 0.8, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple", Price = 0.8, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "orange2", Price = 0.82, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple3", Price = 0.83, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple4", Price = 0.84, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple5", Price = 0.85, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple6", Price = 0.86, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple7", Price = 0.87, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple", Price = 0.8, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple", Price = 0.8, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "orange2", Price = 0.82, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple3", Price = 0.83, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple4", Price = 0.84, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple5", Price = 0.85, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple6", Price = 0.86, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple7", Price = 0.87, CreatedTime = DateTime.Now},
                    new Order() {Id = Guid.NewGuid(), Name = "apple", Price = 0.8, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple", Price = 0.8, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "orange2", Price = 0.82, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple3", Price = 0.83, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple4", Price = 0.84, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple5", Price = 0.85, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple6", Price = 0.86, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple7", Price = 0.87, CreatedTime = DateTime.Now},
                    new Order() {Id = Guid.NewGuid(), Name = "apple", Price = 0.8, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple", Price = 0.8, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "orange2", Price = 0.82, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple3", Price = 0.83, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple4", Price = 0.84, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple5", Price = 0.85, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple6", Price = 0.86, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple7", Price = 0.87, CreatedTime = DateTime.Now},
                    new Order() {Id = Guid.NewGuid(), Name = "apple", Price = 0.8, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple", Price = 0.8, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "orange2", Price = 0.82, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple3", Price = 0.83, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple4", Price = 0.84, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple5", Price = 0.85, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple6", Price = 0.86, CreatedTime = DateTime.Now},
                new Order() {Id = Guid.NewGuid(), Name = "apple7", Price = 0.87, CreatedTime = DateTime.Now},
            };
           
           BindData(new ObservableCollection<Order>(orders));
        }

        public void BindData(ObservableCollection<Order> orders)
        {
            DataGrid01.ItemsSource = null;
            DataGrid01.ItemsSource = orders;
        }

        private void CheckNone_OnChecked(object sender, RoutedEventArgs e)
        {
            CheckNone = sender as CheckBox;

            if (CheckAll != null && CheckAll.IsChecked == true)
            {
                CheckAll.IsChecked = false;
            }

            List<Order> orders = new List<Order>();
            foreach (Order item in DataGrid01.Items)
            {
                item.IsChecked = false;
                orders.Add(item);
            }

            BindData(new ObservableCollection<Order>(orders));

            tb01.Text = orders.Count(r => r.IsChecked).ToString();
        }

        private void CheckAll_OnChecked(object sender, RoutedEventArgs e)
        {
            CheckAll = sender as CheckBox;

            if (CheckNone != null && CheckNone.IsChecked == true)
            {
                CheckNone.IsChecked = false;
            }

            List<Order> orders = new List<Order>();
            foreach (Order item in DataGrid01.Items)
            {
                item.IsChecked = true;
                orders.Add(item);
            }

            BindData(new ObservableCollection<Order>(orders));

            tb01.Text = orders.Count(r => r.IsChecked).ToString();
        }

        private System.Windows.Controls.CheckBox CheckAll, CheckNone;
        private TextBlock tb01;
        private void Tb01_OnInitialized(object sender, EventArgs e)
        {
            tb01 = sender as TextBlock;
        }

        private void DataGrid01_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (Order item in DataGrid01.SelectedItems)
            {
                item.IsChecked = true;
            }
        }

        private void DataGrid01_OnCellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            
        }

        private void DataGrid01_OnRowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {

        }

        private void DataGrid01_OnSelected(object sender, RoutedEventArgs e)
        {
        }

        private void DataGrid01_OnSelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            if(tb01 != null)
            tb01.Text = DataGrid01.SelectedItems.Count.ToString();

            foreach (Order order in DataGrid01.Items)
            {
                order.IsChecked = false;
            }
            foreach (Order order in DataGrid01.SelectedItems)
            {
                order.IsChecked = true;
            }
        }
    }
}
