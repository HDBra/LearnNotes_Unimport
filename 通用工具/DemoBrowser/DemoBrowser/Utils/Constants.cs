using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoBrowser.Utils
{
    /// <summary>
    /// 定义常量
    /// </summary>
    public class Constants
    {
        /// <summary>
        /// 标题
        /// </summary>
        public const string MainTitle = "MainTitle";

        /// <summary>
        /// 浏览器默认显示的Url
        /// </summary>
        public const string DefaultUrl = "DefaultUrl";

        /// <summary>
        /// 有0个或多个项组成，
        /// 每项采用  消息|url 格式，用|分割消息和url ，消息不区分大小写
        /// 每个项之间用;分割
        /// </summary>
        public const string MessageUrlPair = "MessageUrlPair";



    }
}
