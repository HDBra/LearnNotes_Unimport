using System;
using System.IO;
using System.Linq;
using LogCleaner.Utils;
using Quartz;

namespace LogCleaner.Quartzs
{
    /// <summary>
    /// 清理日志的job
    /// </summary>
    public class CleanLogJob:IJob
    {
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

            try
            {
                NLogHelper.Info("开始清理日志");
                DirectoryInfo dirInfo = new DirectoryInfo(LogDir);
                if (!dirInfo.Exists)
                {
                    NLogHelper.Info("未找到{0}日志目录，无法清理".FormatWith(LogDir));
                    return;
                }

                DriveInfo driveInfo = null;

                foreach (DriveInfo item in DriveInfo.GetDrives())
                {
                    if (dirInfo.Root.Name == item.Name)
                    {
                        driveInfo = item;
                        break;
                    }
                }

                DateTime expireTime;//过期时间
                if (driveInfo != null && driveInfo.AvailableFreeSpace < driveInfo.TotalSize*DriveAvailableLimit)
                {
                    //当到达硬盘利用极限时，保存的天数
                    expireTime = DateTime.Now.Subtract(new TimeSpan(KeepDaysWhenAvailableLimit, 0, 0, 0));
                }
                else
                {
                    expireTime = DateTime.Now.Subtract(new TimeSpan(KeepDays, 0, 0, 0));
                }

                //删除过期日志
                foreach (FileInfo fileInfo in dirInfo.GetFiles("*.log", SearchOption.AllDirectories))
                {
                    if (fileInfo.CreationTime < expireTime)
                    {
                        fileInfo.Delete();
                        NLogHelper.Info("删除日志文件："+fileInfo.FullName);
                    }
                }

                //删除空目录
                foreach (var currentDir in dirInfo.GetDirectories("*", SearchOption.AllDirectories))
                {
                    if (!currentDir.GetFileSystemInfos().Any())
                    {
                        currentDir.Delete();
                        NLogHelper.Info("删除日志目录："+currentDir.FullName);
                    }
                }

            }
            catch (Exception ex)
            {
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
        /// 要清理日志的目录
        /// </summary>
        private const string LogDir = "Logs";

        /// <summary>
        /// 保存多少天日志，与创建时间比较
        /// </summary>
        private const int KeepDays = 300;

        /// <summary>
        /// 硬盘空间极限可用值。
        /// 当硬盘可用空间小于当前值时，清理日志,只保存KeepDaysWhenAvailableLimit天，否则保存KeepDays天
        /// </summary>
        private const double DriveAvailableLimit = 0.09;

        /// <summary>
        /// 当到达硬盘利用极限时，保存的天数
        /// </summary>
        private const int KeepDaysWhenAvailableLimit = 90;

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
