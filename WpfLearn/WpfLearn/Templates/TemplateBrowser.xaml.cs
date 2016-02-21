using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml;

namespace WpfLearn.Templates
{
    /// <summary>
    /// TemplateBrowser.xaml 的交互逻辑
    /// </summary>
    public partial class TemplateBrowser : Window
    {
        public TemplateBrowser()
        {
            InitializeComponent();
        }

        private void LstTypes_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Type type = (Type) (lstTypes.SelectedItem);
                if (type == null)
                {
                    return;
                }
                ConstructorInfo info = type.GetConstructor(System.Type.EmptyTypes);

                if (info == null)
                {
                    return;
                }

                Control control = (Control) info.Invoke(null);
                control.Visibility = Visibility.Collapsed;
                grid01.Children.Add(control);

                ControlTemplate template = control.Template;
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                StringBuilder sb = new StringBuilder();
                XmlWriter writer = XmlWriter.Create(sb,settings);
                XamlWriter.Save(template, writer);
                txtTemplate.Text = sb.ToString();
                grid01.Children.Remove(control);

            }
            catch (Exception ex)
            {
                txtTemplate.Text = string.Format("error happened:{0}{1}",Environment.NewLine,ex);

            }
        }

        private void TemplateBrowser_OnLoaded(object sender, RoutedEventArgs e)
        {
            Type controlType = typeof (Control);
            List<Type> derivedTypes = new List<Type>();
            Assembly assembly = Assembly.GetAssembly(typeof(Control));
            foreach (var type in assembly.GetTypes())
            {
                if (type.IsSubclassOf(controlType) && !type.IsAbstract && type.IsPublic)
                {
                    derivedTypes.Add(type);
                }
            }

            derivedTypes.Sort(new TypeComparer());

            lstTypes.ItemsSource = derivedTypes;

        }
    }

    public class TypeComparer : IComparer<Type>
    {
        public int Compare(Type x, Type y)
        {
            return String.Compare(x.Name, y.Name, StringComparison.Ordinal);
        }
    }

}
