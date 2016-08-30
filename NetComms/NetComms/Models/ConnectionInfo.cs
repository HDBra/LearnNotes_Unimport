using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetComms.Models
{

    /// <summary>
    /// 连接信息
    /// </summary>
    public class ConnectionInfo : IEquatable<ConnectionInfo>, IExplicitlySerialize
    {

        #region 私有字段

        /// <summary>
        /// 网络连接点的唯一标识
        /// </summary>
        private string NetworkIdentifierStr;

        /// <summary>
        /// 本地地址
        /// </summary>
        private string localEndPointAddressStr;

        /// <summary>
        /// 本地端口
        /// </summary>
        private int localEndPointPort;

        /// <summary>
        /// 是否缓存hashCode
        /// </summary>
        private bool hashCodeCacheSet = false;

        /// <summary>
        /// hashCode
        /// </summary>
        private int hashCodeCache;

        #endregion


        /// <summary>
        /// 连接的类型
        /// </summary>
        public ConnectionType ConnectionType { get; internal set; }

        /// <summary>
        /// true if the RemoteEndPoint is connectable
        /// </summary>
        public bool IsConnectable { get; private set; }

        /// <summary>
        /// 本连接对象创建的时间
        /// </summary>
        public DateTime ConnectionCreationTime { get; protected set;}

        /// <summary>
        /// 是否是服务器端
        /// </summary>
        public bool ServerSide { get; internal set; }

        #region IEquatable

        public bool Equals(ConnectionInfo other)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region IExplicitlySerialize

        public void Deserialize(Stream inputStream)
        {
            throw new NotImplementedException();
        }
        

        public void Serialize(Stream outputStream)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
