using System;
using System.Configuration;

namespace DemoBrowser.Utils
{
    /// <summary>
    /// 获取应用程序配置的工具类
    /// </summary>
    public static class ConfigUtils
    {
       
        /// <summary>
        /// 获取配置字符串
        /// </summary>
        /// <param name="key">配置文件的键</param>
        /// <param name="defaultValue">获取不到对应的键值时的默认返回值</param>
        /// <returns></returns>
        public static string GetString(string key,string defaultValue="")
        {
            if(string.IsNullOrEmpty(key))
            {
                return defaultValue;
            }
            try
            {
                string value = ConfigurationManager.AppSettings[key];
                return value ?? defaultValue ;
            }
            catch(Exception)
            {
                return defaultValue;
            }
        }

        /// <summary>
        /// 获取配置的整数值
        /// </summary>
        /// <param name="key">配置文件的键</param>
        /// <param name="defaultValue">获取不到对应的键值时的默认返回值</param>
        /// <returns></returns>
        public static int GetInteger(string key,int defaultValue)
        {
            if(string.IsNullOrEmpty(key))
            {
                return defaultValue;
            }
            try
            {
                int value;
                if(int.TryParse(ConfigurationManager.AppSettings[key],out value))
                {
                    return value;
                }
                else
                {
                    return defaultValue;
                }
            }
            catch (Exception)
            {
                return defaultValue;
            }
        }
        
        /// <summary>
        /// 获取配置的double值
        /// </summary>
        /// <param name="key">配置文件的键</param>
        /// <param name="defaultValue">获取不到对应的键值时的默认返回值</param>
        /// <returns></returns>
        public static double GetDouble(string key,double defaultValue)
        {
            if(string.IsNullOrEmpty(key))
            {
                return defaultValue;
            }
            try
            {
                double value;
                if(double.TryParse(ConfigurationManager.AppSettings[key],out value))
                {
                    return value;
                }
                else
                {
                    return defaultValue;
                }
            }
            catch (Exception)
            {
                return defaultValue;
            }
        }

      
    }
}