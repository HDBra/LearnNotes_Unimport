using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessMonitor.Models
{
    public class MonitorDto
    {
        /// <summary>
        /// 程序名
        /// </summary>
        public string ProgramName { get; set; }
        /// <summary>
        /// 文件名
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string MainWindowTitle { get; set; }

        /// <summary>
        /// 扫描时间
        /// </summary>
        public string ScannerTime { get; set; }
        /// <summary>
        /// 进程数
        /// </summary>
        public int ProcessCount { get; set; }
        /// <summary>
        /// 重启次数
        /// </summary>
        public long RebootCount { get; set; }
        /// <summary>
        /// 重启时间
        /// </summary>
        public string RebootTime { get; set; }
    }
}
