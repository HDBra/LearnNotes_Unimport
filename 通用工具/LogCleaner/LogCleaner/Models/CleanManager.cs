using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogCleaner.Models
{
    /// <summary>
    /// 清理管理器
    /// </summary>
    public static class CleanManager
    {
        /// <summary>
        /// 底层存储，可并行使用
        /// </summary>
        private static ConcurrentDictionary<string,CleanDir> _concurrentDict = new ConcurrentDictionary<string,CleanDir>();

        /// <summary>
        /// 对外提供的
        /// </summary>
        public static ConcurrentDictionary<string, CleanDir> ConcurrentDict
        {
            get
            {
                return _concurrentDict;
            }
        }

        /// <summary>
        /// 快照  获取调用时刻的ConcurrentDict快照
        /// </summary>
        /// <returns></returns>
        public static List<CleanDir> Snapshot()
        {
            IEnumerator<KeyValuePair<string,CleanDir>> enumerator = _concurrentDict.GetEnumerator();

            List<CleanDir> list = new List<CleanDir>();

            while (enumerator.MoveNext())
            {
                list.Add(enumerator.Current.Value);
            }

            return list;
        }


        /// <summary>
        /// 快照 获取调用时刻的ConcurrentDict快照
        /// </summary>
        /// <returns></returns>
        public static List<string> SnapshotDir()
        {
            IEnumerator<KeyValuePair<string, CleanDir>> enumerator = _concurrentDict.GetEnumerator();

            List<string> list = new List<string>();

            while (enumerator.MoveNext())
            {
                list.Add(enumerator.Current.Key);
            }

            return list;
        } 

    }
}
