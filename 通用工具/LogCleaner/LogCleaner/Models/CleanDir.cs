using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using LogCleaner.Utils;

namespace LogCleaner.Models
{
    /// <summary>
    /// 目录清理
    /// </summary>
    public class CleanDir:IComparable<CleanDir>,IEquatable<CleanDir>
    {
        /// <summary>
        /// Job 的 key
        /// </summary>
        public string JobKey { get; set; }

        /// <summary>
        /// 目录
        /// </summary>
        public string Directory { get; set; }

        /// <summary>
        /// 最近一次清理时间
        /// </summary>
        public DateTime LastCleanTime { get; set; }

        /// <summary>
        /// 最近一次清理的文件数
        /// </summary>
        public long LastCleanFileCount { get; set; }

        /// <summary>
        /// 最近一次清理的目录数
        /// </summary>
        public long LastCleanDirCount { get; set; }

        /// <summary>
        /// 最近一次异常，如果为null，表示没有异常
        /// </summary>
        public Exception LastException { get; set; }

        /// <summary>
        /// 保留的日期
        /// </summary>
        public int ReserveDays { get; set; }

        /// <summary>
        /// 执行方式
        /// </summary>
        public string ExecuteManner { get; set; }

        /// <summary>
        /// 接口实现
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(CleanDir other)
        {
            if (other == null)
            {
                //null最小
                return 1;
            }

            if (Directory == other.Directory)
            {
                return 0;
            }

            if (StringUtils.EqualsEx(Directory, other.Directory))
            {
                return 0;
            }
            //该方法接受的第一和第二个参数可以为null
            return String.Compare(Directory, other.Directory, StringComparison.Ordinal);
        }

        /// <summary>
        /// 接口实现
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(CleanDir other)
        {
            if (other == null)
            {
                return false;
            }

            return StringUtils.EqualsEx(Directory, other.Directory);
        }
    }

    /// <summary>
    /// 清理方式
    /// </summary>
    public enum CleanMode
    {
        ByDay,//按天
        ByWeek,//按周
        ByMonth//按月
    }

    public class CleanDetail
    {
        /// <summary>
        /// 清理方式
        /// </summary>
        public CleanMode CleanMode { get; set; }
    }
}
