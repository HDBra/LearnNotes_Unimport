using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WpfLearn.Deletable
{
    public class TileView:ViewBase
    {
        /// <summary>
        /// 数据模板，描述如何显示数据
        /// </summary>
        private DataTemplate itemTemplate;

        /// <summary>
        /// 数据模板，描述如何显示一项数据
        /// </summary>
        public DataTemplate ItemTemplate
        {
            get { return itemTemplate; }
            set { itemTemplate = value; }
        }

        /// <summary>
        ///  样式对象，用来设定ListView本身的样式
        /// </summary>
        protected override object DefaultStyleKey
        {
            get { return new ComponentResourceKey(GetType(), "TileView"); }
        }

        /// <summary>
        /// view中Item项的样式
        /// </summary>
        protected override object ItemContainerDefaultStyleKey
        {
            //获取type类型key指定的键的名字的资源
            get { return new ComponentResourceKey(GetType(), "TileViewItem"); }
        }
    }
}
