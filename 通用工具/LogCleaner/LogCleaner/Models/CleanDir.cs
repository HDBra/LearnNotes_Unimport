using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using LogCleaner.Quartzs;
using LogCleaner.Utils;
using Quartz;

namespace LogCleaner.Models
{
    /// <summary>
    /// 目录清理
    /// </summary>
    [Serializable]
    public class CleanDir:IComparable<CleanDir>,IEquatable<CleanDir>
    {

        public CleanDir()
        {
            this.CleanDetail = new CleanDetail();
            this.SearchPattern = "*.log|*.txt";
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
        /// 执行方式
        /// </summary>
        public CleanDetail CleanDetail { get; set; }

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

        /// <summary>
        /// 调度这个任务
        /// </summary>
        public void ScheduleJob()
        {
            JobDataMap data = new JobDataMap();
            data.Add(CleanLogJob.DataKey,this);
            IJobDetail job = QuartzHelper.GetInstance().CreateJob(Directory,typeof(CleanLogJob),data);
            ITrigger trigger = QuartzHelper.GetInstance().CreateCronTrigger(Directory + "Trigger", this.CleanDetail.CronExpression);
            QuartzHelper.GetInstance().ScheduleJob(job,trigger);
        }
    }

    /// <summary>
    /// 清理日志
    /// </summary>
    public class CleanLog
    {
        public CleanLog()
        {
            CleanDir = new CleanDir();
        }
        /// <summary>
        /// 目录清理
        /// </summary>
        public CleanDir CleanDir { get; set; }

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

        public CleanDetail()
        {
            WeekOrMonthList = new List<string>();
        }

        /// <summary>
        /// 清理方式
        /// </summary>
        public CleanMode CleanMode { get; set; }

        /// <summary>
        /// 生成的Cron表达式
        /// </summary>
        public string CronExpression { get; set; }

        /// <summary>
        /// 清理的周或者月
        /// </summary>
        public List<string> WeekOrMonthList { get; set; }

        /// <summary>
        /// 按天执行的Cron表达式格式
        /// </summary>
        public const string DayCronFormat = "{0} {1} {2} * * ?";

        /// <summary>
        /// 按周执行的cron
        /// </summary>
        public const string WeekCronFormat = "{0} {1} {2} ? * {3}";

        /// <summary>
        /// 按月执行的cron
        /// </summary>
        public const string MonthCronFormat = "{0} {1} {2} {3} * ?";
    }
}
