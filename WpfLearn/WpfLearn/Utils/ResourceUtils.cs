using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Resources;

namespace WpfLearn.Utils
{
    /// <summary>
    /// 资源管理
    /// 创建资源，将资源生成操作设置为Resource
    /// </summary>
    public static class ResourceUtils
    {
        /// <summary>
        /// 获取资源，  
        /// </summary>
        /// <param name="resUri">例如  image/dessert.jpg</param>
        /// <returns></returns>
        public static StreamResourceInfo GetAppResourceInfo(String resUri)
        {
            return Application.GetResourceStream(new Uri(resUri, UriKind.Relative));
        }

        /// <summary>
        /// 获取图片资源
        /// </summary>
        /// <param name="resUri"></param>
        /// <returns></returns>
        public static BitmapImage GetBitmapImage(String resUri)
        {
            return new BitmapImage(new Uri(resUri,UriKind.Relative));
        }

        /// <summary>
        /// 获取图片资源
        /// </summary>
        /// <param name="resUri"></param>
        /// <returns></returns>
        public static BitmapImage GetBitmapImage2(String resUri)
        {
            return new BitmapImage(new Uri(resUri, UriKind.Relative));
        }
    }
}


