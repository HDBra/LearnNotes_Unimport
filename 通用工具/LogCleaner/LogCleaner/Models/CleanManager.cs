using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogCleaner.Quartzs;
using LogCleaner.Utils;

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
        private static ConcurrentDictionary<string,CleanLog> _concurrentDict = new ConcurrentDictionary<string,CleanLog>();

        /// <summary>
        /// 对外提供的
        /// </summary>
        public static ConcurrentDictionary<string, CleanLog> ConcurrentDict
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
        public static List<CleanLog> Snapshot()
        {
            IEnumerator<KeyValuePair<string,CleanLog>> enumerator = _concurrentDict.GetEnumerator();

            List<CleanLog> list = new List<CleanLog>();

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
            IEnumerator<KeyValuePair<string, CleanLog>> enumerator = _concurrentDict.GetEnumerator();

            List<string> list = new List<string>();

            while (enumerator.MoveNext())
            {
                list.Add(enumerator.Current.Key);
            }

            return list;
        }

        /// <summary>
        /// 是否管理  true表示被管理 false表示未被管理
        /// </summary>
        /// <param name="dir"></param>
        /// <returns></returns>
        public static bool IsManaged(string dir)
        {
            //获取快照
            List<string> snapList = SnapshotDir();
            foreach (string item in snapList)
            {
                if (StringUtils.EqualsEx(item, dir))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// 新增一个清理job
        /// 调用方确保job是新增的
        /// </summary>
        /// <param name="cleanDir"></param>
        public static void AddCleanJob(CleanDir cleanDir)
        {
            CleanLog cleanLog = new CleanLog();
            cleanLog.CleanDir = cleanDir;
            //加入管理
            if (CleanManager.ConcurrentDict.TryAdd(cleanDir.Directory.Trim().ToLower(), cleanLog))
            {
                List<CleanDir> cleanDirs = CleanManager.Snapshot().Select(r=>r.CleanDir).ToList();
                //保存到配置文件
                SerializeHelper.ToFile(cleanDirs, SerializeHelper.DestFile);
                //加入到调度任务中
                cleanDir.ScheduleJob(cleanLog);
            }
        }

        /// <summary>
        /// 删除清理job
        /// </summary>
        /// <param name="directory"></param>
        /// <returns></returns>
        public static bool DeleteCleanJob(string directory)
        {
            if (string.IsNullOrEmpty(directory))
            {
                return false;
            }
            directory = directory.Trim().ToLower();
            CleanLog cleanLog = null;
            if (CleanManager.ConcurrentDict.TryRemove(directory, out cleanLog))
            {
                List<CleanDir> cleanDirs = CleanManager.Snapshot().Select(r => r.CleanDir).ToList();
                //保存到配置文件
                SerializeHelper.ToFile(cleanDirs, SerializeHelper.DestFile);
                //删除job
                cleanLog.CleanDir.DeleteJob();
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
