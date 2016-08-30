using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetComms.Models
{
    /// <summary>
    /// 连接的类型
    /// </summary>
    public enum ConnectionType
    {

        /// <summary>
        /// 无定义，这是默认值
        /// </summary>
        Undefined,

        /// <summary>
        /// TCP连接
        /// </summary>
        TCP,

        /// <summary>
        /// UDP连接
        /// </summary>
        UDP,

    }
}
