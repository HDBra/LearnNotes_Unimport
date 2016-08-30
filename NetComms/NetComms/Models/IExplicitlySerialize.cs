using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetComms.Models
{
    /// <summary>
    /// 实现序列化和逆序列化的显式接口
    /// </summary>
    public interface IExplicitlySerialize
    {

        /// <summary>
        /// 序列化成字节到输出流
        /// </summary>
        /// <param name="outputStream"></param>
        void Serialize(Stream outputStream);

        /// <summary>
        /// 从输入流中逆序列为对象
        /// </summary>
        /// <param name="inputStream"></param>
        void Deserialize(Stream inputStream);

    }
}
