using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using LogCleaner.Models;
using LogCleaner.Utils;
using Quartz;

namespace LogCleaner.Quartzs
{
    /// <summary>
    /// 清理日志的job
    /// </summary>
    public class CleanLogJob:IJob
    {
        public const string DataKey = "CleanDataKey";

        #region 回调Job
        /// <summary>
        /// 清理日志job
        /// </summary>
        /// <param name="context"></param>
        public void Execute(IJobExecutionContext context)
        {
            lock (locker)
            {
                if (isRunning)
                {
                    return;
                }
                isRunning = true;
            }
            
            CleanLog cleanLog = null;

            try
            {
                NLogHelper.Info("开始清理日志");
                JobDataMap datamap = context.MergedJobDataMap;
                Object obj = datamap[DataKey];
                if (obj == null)
                {
                    NLogHelper.Error("未获取到Job的dataMap");
                    return;
                }

                cleanLog = obj as CleanLog;
                if (cleanLog == null)
                {
                    NLogHelper.Error("未获取到Job的dataMap");
                    return;
                }
                string dir = cleanLog.CleanDir.Directory;
                int keepDays = cleanLog.CleanDir.ReserveDays;
                string searchPatterns = cleanLog.CleanDir.SearchPattern;
                DirectoryInfo dirInfo = new DirectoryInfo(dir);

                if (!dirInfo.Exists)
                {
                    NLogHelper.Info("未找到{0}日志目录，无法清理".FormatWith(dir));
                    return;
                }

                //过期时间
                DateTime expireTime = DateTime.Now.Subtract(new TimeSpan(keepDays,0,0,0));
                cleanLog.LastCleanTime = DateTime.Now;
                long deleteFileCount = 0;
                string[] searchPatternArr = searchPatterns.Split(new char[] {'|'}, StringSplitOptions.RemoveEmptyEntries).Where(r=>!string.IsNullOrWhiteSpace(r)).Select(r=>r.Trim()).ToArray();

                HashSet<string> fileInfos = new HashSet<string>();
                foreach (string searchPatternItem in searchPatternArr)
                {
                    dirInfo.GetFiles(searchPatternItem, SearchOption.AllDirectories).Select(r => r.FullName).ToList().ForEach(r=>fileInfos.Add(r.ToLower().Trim()));
                }
                //删除过期日志
                foreach (string file in fileInfos)
                {
                    FileInfo fileInfo = new FileInfo(file);
                    if (fileInfo.CreationTime < expireTime)
                    {
                        fileInfo.Delete();
                        deleteFileCount++;
                    }
                }

                cleanLog.LastCleanFileCount = deleteFileCount;

                long deleteDirCount = 0;
                //删除空目录
                foreach (var currentDir in dirInfo.GetDirectories("*", SearchOption.AllDirectories))
                {
                    if (!currentDir.GetFileSystemInfos().Any())
                    {
                        currentDir.Delete();
                        deleteDirCount++;
                    }
                }
                cleanLog.LastCleanDirCount = deleteDirCount;
                NLogHelper.Info(string.Format("清理{0}成功",dir));
                MainWindow.Refresh();
            }
            catch (Exception ex)
            {
                if (cleanLog != null)
                {
                    cleanLog.LastException = ex;
                }
                NLogHelper.Error("清理日志失败："+ex);
            }
            finally
            {
                lock (locker)
                {
                    isRunning = false;
                }
            }
        }
        #endregion

        #region 辅助属性

        /// <summary>
        /// 锁
        /// </summary>
        private static Object locker = new Object();

        /// <summary>
        /// 回调函数是否正在执行
        /// </summary>
        private static bool isRunning = false;

        #endregion
    }
}
