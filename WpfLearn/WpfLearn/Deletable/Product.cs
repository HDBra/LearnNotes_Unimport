using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfLearn.Deletable
{
    /// <summary>
    /// 如果是集合使用 ObservableCollection<T>,来实现自动通知
    /// 或者使用DataTable.DefaultView
    /// </summary>
    public class Product : INotifyPropertyChanged
    {
        private string modelNumber;

        public string ModelNumber
        {
            get { return modelNumber; }
            set
            {
                modelNumber = value;
                OnPropertyChanged(new PropertyChangedEventArgs("ModelNumber"));
            }
        }

        private string modelName;

        public string ModelName
        {
            get { return modelName; }
            set
            {
                modelName = value;
                OnPropertyChanged(new PropertyChangedEventArgs("ModelName"));
            }
        }

        private decimal unitCost;

        public decimal UnitCost
        {
            get { return unitCost; }
            set
            {
                unitCost = value;
                OnPropertyChanged(new PropertyChangedEventArgs("UnitCost"));
            }
        }

        private string description;

        public string Description
        {
            get { return description; }
            set
            {
                description = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Description"));
            }
        }

        public Product(string modelNumber, string modelName, decimal unitCost, string description)
        {
            ModelNumber = modelNumber;
            ModelName = modelName;
            UnitCost = unitCost;
            Description = description;
        }


        public Product()
        {
            
        }

        public static List<Product> GetProducts()
        {
            List<Product> products = new List<Product>();
            products.Add(new Product("1", "Tools", 10, "desc"));
            products.Add(new Product("2", "ModelName111", 10, "desc"));
            products.Add(new Product("3", "ModelName111", 10, "desc"));
            return products;
        } 

    #region 接口实现
        public event PropertyChangedEventHandler PropertyChanged;



        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, e);
            }
        }
        #endregion

    }
}
