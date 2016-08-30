using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetComms.Models
{
    /// <summary>
    /// 定义连接的状态
    /// </summary>
    public enum ConnectionState
    {
        /// <summary>
        /// 未定义连接状态。 This is the starting state of new connections.
        /// </summary>
        Undefined,

        /// <summary>
        /// 连接正在建立或者初始化
        /// </summary>
        Establishing,

        /// <summary>
        /// 连接成功建立
        /// </summary>
        Established,

        /// <summary>
        /// 连接已经关闭
        /// </summary>
        Shutdown
    }
}
