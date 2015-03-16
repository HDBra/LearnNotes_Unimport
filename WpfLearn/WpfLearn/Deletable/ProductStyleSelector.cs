using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WpfLearn.Deletable
{
    /// <summary>
    /// 重新应用一个样式，首先将其设置为null，移除样式，然后重新赋值给予新样式
    /// </summary>
    public class ProductStyleSelector:StyleSelector
    {
        public Style DefaultStyle
        {
            get;
            set;
        }
        public Style HighlightStyle
        {
            get;
            set;
        }
        public string PropertyToEvaluate
        {
            get;
            set;
        }
        public string PropertyValueToHighlight
        {
            get;
            set;
        }
        public override Style SelectStyle(object item, DependencyObject container)
        {
            Product product = (Product)item;
            Window window = Application.Current.MainWindow;
            if (product.ModelName == "Travel")
            {
                return (Style)window.FindResource("TravelProductStyle");
            }
            else
            {
                return (Style)window.FindResource("DefaultProductStyle");
            }
        }
    }
}
