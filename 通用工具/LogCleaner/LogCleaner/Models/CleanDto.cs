using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogCleaner.Utils;

namespace LogCleaner.Models
{
    /// <summary>
    /// 清理ViewModel
    /// </summary>
    public class CleanViewModel
    {
        public CleanViewModel(CleanLog cleanLog)
        {
            if (cleanLog == null)
            {
                return;
            }
            this.Directory = cleanLog.CleanDir.Directory;
            this.SearchPattern = cleanLog.CleanDir.SearchPattern;
            this.ReserveDays = cleanLog.CleanDir.ReserveDays;
            this.CleanDetail = string.Empty;
            if (cleanLog.CleanDir.CleanDetail.CleanMode == CleanMode.ByDay)
            {
                this.CleanDetail = "每天执行 cron={0}".FormatWith(cleanLog.CleanDir.CleanDetail.CronExpression);
            }
            if (cleanLog.CleanDir.CleanDetail.CleanMode == CleanMode.ByWeek)
            {
                this.CleanDetail = "按周执行  cron = {0}".FormatWith(cleanLog.CleanDir.CleanDetail.CronExpression);
            }
            if (cleanLog.CleanDir.CleanDetail.CleanMode == CleanMode.ByMonth)
            {
                this.CleanDetail = "按月执行  cron = {0}".FormatWith(cleanLog.CleanDir.CleanDetail.CronExpression);
            }

            if (cleanLog.LastCleanTime.HasValue)
            {
                this.LastCleanTime = cleanLog.LastCleanTime.Value.ToString("yyyyMMdd HH:mm:ss");
            }

            if (cleanLog.LastException != null)
            {
                this.LastException = cleanLog.LastException.Message;
            }

            this.LastCleanDirCount = cleanLog.LastCleanDirCount;
            this.LastCleanFileCount = cleanLog.LastCleanFileCount;
        }

        /// <summary>
        /// 目录
        /// </summary>
        public string Directory { get; set; }

        /// <summary>
        /// 文件搜索模式
        /// </summary>
        public String SearchPattern { get; set; }

        /// <summary>
        /// 保留的日期
        /// </summary>
        public int ReserveDays { get; set; }

        /// <summary>
        /// 清理详情
        /// </summary>
        public string CleanDetail { get; set; }

        /// <summary>
        /// 最近一次清理时间
        /// </summary>
        public string LastCleanTime { get; set; }

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

        public string LastException { get; set; }
    }
}
