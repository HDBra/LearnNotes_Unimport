using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessMonitor.Models
{
    /// <summary>
    /// 监控程序
    /// </summary>
    public class MonitorProcess
    {
        /// <summary>
        /// 程序路径
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// 程序名
        /// </summary>
        public string ProgramName { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string MainWindowTitle { get; set; }

        /// <summary>
        /// 当前进程数
        /// </summary>
        public int ProcessCount { get; set; }

        /// <summary>
        /// 扫描时间
        /// </summary>
        public DateTime? ScannerTime { get; set; }

        /// <summary>
        /// 重启次数
        /// </summary>
        public long RestartedCount { get; set; }

        /// <summary>
        /// 最近重启时间
        /// </summary>
        public DateTime? RestartTime { get; set; }

    }
}
