using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfLearn.Models
{
    public class PersonModel:INotifyPropertyChanged
    {

        private string _firstName;
        private string _lastName;

        public string FirstName
        {
            get { return _firstName;}
            set
            {
                _firstName = value;
                OnPropertyChanged("FirstName");
            }
        }

        public string LastName
        {
            get { return _lastName;}
            set
            {
                _lastName = value;
                OnPropertyChanged("LastName");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;


        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this,new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
