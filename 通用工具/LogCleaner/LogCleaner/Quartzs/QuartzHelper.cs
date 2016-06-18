using System;
using Quartz;
using Quartz.Impl;
using Quartz.Impl.Matchers;
using Quartz.Impl.Triggers;

namespace LogCleaner.Quartzs
{
    /// <summary>
    /// Quartz任务调度类
    /// </summary>
    public class QuartzHelper
    {

        #region 单例模式

        private static QuartzHelper _instance;

        private QuartzHelper()
        {
            _schedulerFactory = new StdSchedulerFactory();
            _scheduler = _schedulerFactory.GetScheduler();
        }

        /// <summary>
        /// 获取一个实例
        /// </summary>
        /// <returns></returns>
        public static QuartzHelper GetInstance()
        {
            if (_instance != null)
            {
                return _instance;
            }

            if (_instance == null)
            {
                _instance = new QuartzHelper();
            }

            return _instance;
        }
        #endregion

        #region Private Member

        /// <summary>
        /// 调度器工厂
        /// </summary>
        private ISchedulerFactory _schedulerFactory;

        /// <summary>
        /// 调度器
        /// </summary>
        private IScheduler _scheduler;

        #endregion

        #region Public Method

        /// <summary>
        /// 启动调度器
        /// </summary>
        public void Start()
        {
            _scheduler.Start();
            //_scheduler.StartDelayed(new TimeSpan(0,0,2));
        }

        /// <summary>
        /// Halts the Quartz.IScheduler's firing of Quartz.ITriggers, and cleans up all resources associated with the Scheduler.
        /// </summary>
        /// <param name="waitForJobsToComplete">if true the scheduler will not allow this method to return until all currently executing jobs have completed.</param>
        public void Shutdown(bool waitForJobsToComplete = true)
        {
            _scheduler.Shutdown(waitForJobsToComplete);
        }

        /// <summary>
        /// 获取scheduler
        /// </summary>
        /// <returns></returns>
        public IScheduler GetScheduler()
        {
            return _schedulerFactory.GetScheduler();
        }

        /// <summary>
        /// 获取所有的job
        /// </summary>
        /// <returns></returns>
        public Quartz.Collection.ISet<JobKey> GetAllJobs()
        {
            var matcher = GroupMatcher<JobKey>.AnyGroup();
            return _scheduler.GetJobKeys(matcher);
        }


        /// <summary>
        /// 获取指定名称的scheduler
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public IScheduler GetScheduler(String name)
        {
            return _schedulerFactory.GetScheduler(name);
        }

        /// <summary>
        /// 添加一个调度任务
        /// </summary>
        /// <param name="jobDetail"></param>
        /// <param name="trigger"></param>
        public void ScheduleJob(IJobDetail jobDetail, ITrigger trigger)
        {
            _scheduler.ScheduleJob(jobDetail, trigger);
        }

        /// <summary>
        /// 创建一个job
        /// job将会被认为是长久的，使用了默认的组
        /// </summary>
        /// <param name="jobName">job名字，必须唯一</param>
        /// <param name="job"></param>
        /// <param name="data"></param>
        public IJobDetail CreateJob(String jobName, IJob job, JobDataMap data = null)
        {
            IJobDetail jobDetail = new JobDetailImpl(jobName, null, job.GetType(), true, false);

            if (data != null)
            {
                foreach (var keyValuePair in data)
                {
                    jobDetail.JobDataMap.Add(keyValuePair.Key, keyValuePair.Value);
                }
            }
            //添加job的关联数据
            return jobDetail;
        }

        /// <summary>
        /// 创建一个job
        /// job将会被认为是长久的，使用了默认的组
        /// </summary>
        /// <param name="jobName">job名字，必须唯一</param>
        /// <param name="jobtype"></param>
        /// <param name="data"></param>
        public IJobDetail CreateJob(String jobName, Type jobtype, JobDataMap data = null)
        {
            IJobDetail jobDetail = new JobDetailImpl(jobName, null, jobtype, true, false);
            if (data != null)
            {
                foreach (var keyValuePair in data)
                {
                    jobDetail.JobDataMap.Add(keyValuePair.Key, keyValuePair.Value);
                }
            }
            //设置其他信息
            //jobDetail.JobDataMap.Add();
            //添加job的关联数据
            return jobDetail;
        }

        /// <summary>
        /// 暂停一个job
        /// </summary>
        /// <param name="jobName"></param>
        public void Pause(String jobName)
        {
            _scheduler.PauseJob(new JobKey(jobName));
        }

        /// <summary>
        /// Resume一个Job
        /// </summary>
        /// <param name="jobName"></param>
        public void Resume(string jobName)
        {
            _scheduler.ResumeJob(new JobKey(jobName));
        }

        /// <summary>
        /// 删除一个job
        /// </summary>
        /// <param name="jobName"></param>
        public void Delete(string jobName)
        {
            _scheduler.DeleteJob(new JobKey(jobName));
        }

        /// <summary>
        /// 创建一个无限执行的触发器，放入默认的组
        /// trigger将定期按时执行，
        /// 意味着如果下一个周期到来，而上一次周期执行未完成，job仍然在一个新线程中执行
        /// </summary>
        /// <param name="triggerName">触发器的名字，必须唯一</param>
        /// <param name="offsetSeconds">多长时间后触发器执行，单位为秒</param>
        /// <param name="periodSeconds">触发器的执行周期，单位为秒</param>
        /// <returns></returns>
        public ITrigger CreateSimpleTrigger(string triggerName,int offsetSeconds,int periodSeconds)
        {
            ITrigger trigger = new SimpleTriggerImpl(triggerName,DateTimeOffset.UtcNow.AddSeconds(offsetSeconds),null,SimpleTriggerImpl.RepeatIndefinitely,new TimeSpan(0,0,0,periodSeconds));
            return trigger;
        }

        /// <summary>
        /// 创建一个无限执行的触发器, 放入默认的组
        /// trigger将定期按时执行，
        /// 意味着如果下一个周期到来，而上一次周期执行未完成，job仍然在一个新线程中执行
        /// </summary>
        /// <param name="triggerName">触发器的名字，必须唯一</param>
        /// <param name="offsetSeconds">多长时间后触发器执行，单位为秒</param>
        /// <param name="periodSpan">触发器的执行周期</param>
        /// <returns></returns>
        public ITrigger CreateSimpleTrigger(string triggerName, int offsetSeconds, TimeSpan periodSpan)
        {
            ITrigger trigger = new SimpleTriggerImpl(triggerName, DateTimeOffset.UtcNow.AddSeconds(offsetSeconds), null, SimpleTriggerImpl.RepeatIndefinitely, periodSpan);
            return trigger;
        }


        /// <summary>
        /// 创建CronTrigger，立刻执行
        /// trigger将定期按时执行，
        /// 意味着如果下一个周期到来，而上一次周期执行未完成，job仍然在一个新线程中执行
        /// 
        /// Cron表达式由6个(或者7个)空格分隔的时间元素组成，按顺序依次是  
        /// 元素               取值       特殊字符
        /// 秒                (0-59)      ,-*/
        /// 分钟              (0-59)      ,-*/
        /// 小时              (0-23)      ,-*/
        /// day of Month      (1-31）     ,-*?/LW   需要考虑月实际的天数
        /// 月                (1-12)      ,-*/
        /// day of week       (1-7)       ,-*?/L#   1表示星期天 7表示星期六
        /// 年  可选     empty,1970-2099  ,-*/
        /// 
        /// 
        /// *   表示选择所有可能的值，“*”在子表达式（秒）里表示每秒的含义
        /// ?   字符可以用在day-of-month及day-of-week域中，它用来表示“没有指定值”。这对于需要指定一个或者两个域的值而不需要对其他域进行设置来说相当有用。
        /// -   指定范围，如在小时域中，  10-12表示10,11,12点
        /// ,   指定额外的值，如在小时域中，  10,12,12表示10,12,13点
        /// /   指定增量，   在分钟域中，  5/15表示从5分钟开始每隔15分钟执行，即5 20,35,50分钟执行
        /// 
        /// 
        /// 
        /// 0 0 12 * * ?    表示每天12点执行
        /// 0/5 * * * * ?   表示每5秒执行一次
        /// 0 0/5 * * * ?   表示每5分钟执行一次
        /// 0 0 4 5 * ?     每月5日 4 点执行
        /// 0 0 4 ? * 1     每个星期天4点执行
        /// </summary>
        /// <param name="triggerName">triggerName,必须唯一</param>
        /// <param name="cronExpression"></param>
        /// <returns></returns>
        public ITrigger CreateCronTrigger(String triggerName,String cronExpression)
        {
            ITrigger trigger = new CronTriggerImpl(triggerName,null,cronExpression);
            return trigger;
        }


        /// <summary>
        /// 创建CronTrigger
        /// trigger将定期按时执行，
        /// 意味着如果下一个周期到来，而上一次周期执行未完成，job仍然在一个新线程中执行
        /// 
        /// Cron表达式由6个(或者7个)空格分隔的时间元素组成，按顺序依次是  
        /// 元素               取值       特殊字符
        /// 秒                (0-59)      ,-*/
        /// 分钟              (0-59)      ,-*/
        /// 小时              (0-23)      ,-*/
        /// day of Month      (1-31）     ,-*?/LW   需要考虑月实际的天数
        /// 月                (1-12)      ,-*/
        /// day of week       (1-7)       ,-*?/L#   1表示星期天 7表示星期六
        /// 年  可选     empty,1970-2099  ,-*/
        /// 
        /// 
        /// *   表示选择所有可能的值，“*”在子表达式（秒）里表示每秒的含义
        /// ?   字符可以用在day-of-month及day-of-week域中，它用来表示“没有指定值”。这对于需要指定一个或者两个域的值而不需要对其他域进行设置来说相当有用。
        /// -   指定范围，如在小时域中，  10-12表示10,11,12点
        /// ,   指定额外的值，如在小时域中，  10,12,12表示10,12,13点
        /// /   指定增量，   在分钟域中，  5/15表示从5分钟开始每隔15分钟执行，即5 20,35,50分钟执行
        /// 
        /// 
        /// 
        /// 0 0 12 * * ?    表示每天12点执行
        /// 0/5 * * * * ?   表示每5秒执行一次
        /// 0 0/5 * * * ?   表示每5分钟执行一次
        /// 0 0 4 5 * ?     每月5日 4 点执行
        /// 0 0 4 ? * 1     每个星期天4点执行
        /// </summary>
        /// <param name="triggerName">triggerName,必须唯一</param>
        /// <param name="startTime">trigger起始执行的时间</param>
        /// <param name="cronExpression"></param>
        /// <returns></returns>
        public ITrigger CreateCronTrigger(String triggerName,DateTimeOffset startTime, String cronExpression)
        {
            ITrigger trigger =
                TriggerBuilder.Create()
                    .StartAt(startTime)
                    .WithIdentity(triggerName)
                    .WithCronSchedule(cronExpression)
                    .Build();
            return trigger;
        }

        /// <summary>
        /// 创建CronTrigger
        /// trigger将定期按时执行，
        /// 意味着如果下一个周期到来，而上一次周期执行未完成，job仍然在一个新线程中执行
        /// 
        /// Cron表达式由6个(或者7个)空格分隔的时间元素组成，按顺序依次是  
        /// 元素               取值       特殊字符
        /// 秒                (0-59)      ,-*/
        /// 分钟              (0-59)      ,-*/
        /// 小时              (0-23)      ,-*/
        /// day of Month      (1-31）     ,-*?/LW   需要考虑月实际的天数
        /// 月                (1-12)      ,-*/
        /// day of week       (1-7)       ,-*?/L#   1表示星期天 7表示星期六
        /// 年  可选     empty,1970-2099  ,-*/
        /// 
        /// 
        /// *   表示选择所有可能的值，“*”在子表达式（秒）里表示每秒的含义
        /// ?   字符可以用在day-of-month及day-of-week域中，它用来表示“没有指定值”。这对于需要指定一个或者两个域的值而不需要对其他域进行设置来说相当有用。
        /// -   指定范围，如在小时域中，  10-12表示10,11,12点
        /// ,   指定额外的值，如在小时域中，  10,12,12表示10,12,13点
        /// /   指定增量，   在分钟域中，  5/15表示从5分钟开始每隔15分钟执行，即5 20,35,50分钟执行
        /// 
        /// 
        /// 
        /// 0 0 12 * * ?    表示每天12点执行
        /// 0/5 * * * * ?   表示每5秒执行一次
        /// 0 0/5 * * * ?   表示每5分钟执行一次
        /// 0 0 4 5 * ?     每月5日 4 点执行
        /// 0 0 4 ? * 1     每个星期天4点执行
        /// </summary>
        /// <param name="triggerName">triggerName,必须唯一</param>
        /// <param name="offsetSeconds">trigger起始执行的时间,以秒为单位</param>
        /// <param name="cronExpression"></param>
        /// <returns></returns>
        public ITrigger CreateCronTrigger(String triggerName, int offsetSeconds, String cronExpression)
        {
            ITrigger trigger =
                TriggerBuilder.Create()
                    .StartAt(DateTimeOffset.UtcNow.AddSeconds(offsetSeconds))
                    .WithIdentity(triggerName)
                    .WithCronSchedule(cronExpression)
                    .Build();
            return trigger;
        }
        #endregion
    }
}
