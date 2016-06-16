using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace LogCleaner.Utils
{
    /// <summary>
    /// 根据github，nlog比log4net更好
    /// nlog自动查找程序目录的NLog.config来配置程序
    /// </summary>
    public static class NLogHelper
    {
        /// <summary>
        /// 私有的logger类
        /// Logger类是多线程安全的
        /// 实际使用中在对应的类中创建一个_logger，这样就可以使用${callsite}了
        /// </summary>
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        //private static Logger _logger = LogManager.GetLogger("fileandconsole");

        ///// <summary>
        ///// 获取指定名字的日志
        ///// </summary>
        ///// <param name="name"></param>
        ///// <returns></returns>
        //public static void SetLoggerName(string name)
        //{
        //    _logger = LogManager.GetLogger(name);
        //}

        /// <summary>
        /// 记录Trace日志
        /// </summary>
        /// <param name="message"></param>
        public static void Trace(string message)
        {
            if (string.IsNullOrEmpty(message))
            {
                return;
            }
            try
            {
                _logger.Trace(message);
            }
            catch (Exception)
            {

            }
        }

        /// <summary>
        /// 记录Debug日志
        /// </summary>
        /// <param name="message"></param>
        public static void Debug(string message)
        {
            if (string.IsNullOrEmpty(message))
            {
                return;
            }
            try
            {
                _logger.Debug(message);
            }
            catch (Exception)
            {

            }

        }

        /// <summary>
        /// 记录Info信息
        /// </summary>
        /// <param name="message"></param>
        public static void Info(string message)
        {
            if (string.IsNullOrEmpty(message))
            {
                return;
            }
            try
            {
                _logger.Info(message);
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// 记录Warn日志
        /// </summary>
        /// <param name="message"></param>
        public static void Warn(string message)
        {
            if (string.IsNullOrEmpty(message))
            {
                return;
            }
            try
            {
                _logger.Warn(message);
            }
            catch (Exception)
            {

            }

        }


        /// <summary>
        /// 记录Error日志
        /// </summary>
        /// <param name="message"></param>
        public static void Error(string message)
        {
            if (string.IsNullOrEmpty(message))
            {
                return;
            }
            try
            {
                _logger.Error(message);
            }
            catch (Exception)
            {

            }
        }

        /// <summary>
        /// 记录Fetal日志
        /// </summary>
        /// <param name="message"></param>
        public static void Fatal(string message)
        {
            if (string.IsNullOrEmpty(message))
            {
                return;
            }
            try
            {
                _logger.Fatal(message);
            }
            catch (Exception)
            {

            }
        }

        ///// <summary>
        ///// 格式化数据
        ///// </summary>
        ///// <param name="format"></param>
        ///// <param name="args"></param>
        ///// <returns></returns>
        //public static string FormatWith(this string format, params object[] args)
        //{
        //    return string.Format(format, args);
        //}


        /// <summary>
        /// format
        /// </summary>
        /// <param name="s"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static string FormatWith(this string s, params object[] args)
        {
            
            if (args == null || args.Length == 0)
            {
                return s;
            }

            return string.Format(s, args);
        }

    }

}
