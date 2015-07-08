using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;

namespace WpfLearn.Utils
{
    /// <summary>
    /// wpf帮助类
    /// </summary>
    public static class WpfUtils
    {
        /// <summary>
        /// 从xamlFile文件中加载解析xaml,将其转换为DependencyObject对象
        /// </summary>
        /// <param name="xmlFile">xaml文件的地址</param>
        /// <returns></returns>
        public static DependencyObject LoadFromXmlFile(String xmlFile)
        {
            DependencyObject dependencyObject = null;
            using (FileStream fs = new FileStream(xmlFile, FileMode.Open))
            {
                dependencyObject = (DependencyObject)XamlReader.Load(fs);
            }
            return dependencyObject;
        }
        /// <summary>
        ///  读取指定文本字符串中的 XAML 输入，并返回与指定标记的根对应的对象。
        /// </summary>
        /// <param name="xaml">输入 XAML，作为单个文本字符串。</param>
        /// <returns> 已创建的对象树的根。</returns>

        public static DependencyObject LoadFromString(String xaml)
        {
            return (DependencyObject)XamlReader.Parse(xaml);
        }

        /// <summary>
        /// 尝试查找并返回具有指定名称的对象。 搜索从指定对象开始，并持续到逻辑树的子节点中。
        /// </summary>
        /// <param name="name"> 要查找的对象的名称。</param>
        /// <param name="dependencyObject"></param>
        /// <returns></returns>
        public static FrameworkElement FindViewByName(string name, DependencyObject dependencyObject)
        {
            return (FrameworkElement)LogicalTreeHelper.FindLogicalNode(dependencyObject, name);
        }

        /// <summary>
        /// 查找具有提供的标识符名的元素。
        /// </summary>
        /// <param name="name"></param>
        /// <param name="fe"></param>
        /// <returns></returns>
        public static FrameworkElement FindViewByName2(string name, FrameworkElement fe)
        {
            return (FrameworkElement) fe.FindName(name);
        }
    }
}