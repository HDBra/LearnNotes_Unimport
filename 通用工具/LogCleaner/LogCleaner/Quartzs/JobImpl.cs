using System;
using System.Threading;
using Quartz;

namespace LogCleaner.Quartzs
{
    /// <summary>
    /// 一个job实现
    /// </summary>
    public class JobImpl:IJob
    {
        #region IJob实现
        /// <summary>
        /// 注：该方法将定期按时执行，
        /// 意味着如果下一个周期到来，而上一次执行未完成，该方法开启一个新线程执行
        /// </summary>
        /// <param name="context"></param>
        public void Execute(IJobExecutionContext context)
        {
            JobDataMap dataMap = context.JobDetail.JobDataMap;//获取job的数据
            
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId+"   "+DateTime.Now.ToString());
        }

        /// <summary>
        /// 每次job执行均创建一个job实例
        /// </summary>
        public JobImpl()
        {
            Console.WriteLine("创建一个job实例");
        }
        #endregion
    }
}
