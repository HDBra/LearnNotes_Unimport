using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessMonitor.Utils
{
    public static class StringUtils
    {
        /// <summary>
        /// format
        /// </summary>
        /// <param name="s"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static string FormatWith(string s, params object[] args)
        {
            if (s == null)
            {
                return string.Empty;
            }

            if (args == null || args.Length == 0)
            {
                return s;
            }

            return string.Format(s, args);
        }

        /// <summary>
        /// 截短字符串
        /// 如果字符串为null，返回string.Empty
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string TrimEx(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }

            return s.Trim();
        }

        /// <summary>
        /// 忽略字符串前后空白，比较字符串是否相同
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <param name="ignoreCase"></param>
        /// <returns></returns>
        public static bool EqualsEx(string s1, string s2, bool ignoreCase = true)
        {
            if (string.IsNullOrWhiteSpace(s1) && string.IsNullOrWhiteSpace(s2))
            {
                return true;
            }

            if (s1 == null || s2 == null)
            {
                //此时s1 , s2不可能同时为null
                return false;
            }

            if (ignoreCase)
            {
                return String.Equals(s1.Trim(), s2.Trim(), StringComparison.CurrentCultureIgnoreCase);
            }
            else
            {
                return s1.Trim() == s2.Trim();
            }
        }
    }
}
