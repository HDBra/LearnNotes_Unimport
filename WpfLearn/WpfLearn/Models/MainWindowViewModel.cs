using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WpfLearn.Models
{
    public class MainWindowViewModel:INotifyPropertyChanged
    {
        private PersonModel _model;
        private string _fullName;

        public MainWindowViewModel()
        {
            _model = new PersonModel()
            {
                FirstName = "Tom",
                LastName = "James"
            };

            FullName = string.Format("{0} {1}", _model.FirstName, _model.LastName);
        }


        public string FirstName
        {
            get { return _model.FirstName; }
            set
            {
                _model.FirstName = value;
                FullName = string.Format("{0} {1}",_model.FirstName, _model.LastName);
                OnPropertyChanged("FirstName");
            }
        }

        public string LastName
        {
            get { return _model.LastName; }
            set
            {
                _model.LastName = value;
                FullName = string.Format("{0} {1}",_model.FirstName, _model.LastName);
                OnPropertyChanged();
            }
        }

        public string FullName
        {
            get { return _fullName;}
            set
            {
                _fullName = value;
                OnPropertyChanged("FullName");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;


        public void OnPropertyChanged([CallerMemberName] string propertyName="")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}
