using System;
using System.Collections.Generic;
using System.Text;
using NLog;

namespace Utils
{
    public static class NLogHelper
    {
        /// <summary>
        /// 私有的logger类
        /// </summary>
        //private static Logger _logger = LogManager.GetCurrentClassLogger();

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
                LogManager.GetCurrentClassLogger().Trace(message);
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
                LogManager.GetCurrentClassLogger().Debug(message);
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
                LogManager.GetCurrentClassLogger().Info(message);
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
                LogManager.GetCurrentClassLogger().Warn(message);
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
                LogManager.GetCurrentClassLogger().Error(message);
            }
            catch (Exception)
            {
               
            }
        }

        /// <summary>
        /// 记录Fetal日志
        /// </summary>
        /// <param name="message"></param>
        public static void Fetal(string message)
        {
            if (string.IsNullOrEmpty(message))
            {
                return;
            }
            try
            {
                LogManager.GetCurrentClassLogger().Fatal(message);
            }
            catch (Exception)
            {
               
            }
        }
    }
}