using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;

namespace StandardMVC.Utils
{
    /// <summary>
    /// Action Helper
    /// </summary>
    public static class ActionHelper
    {
        /// <summary>
        /// 获取用户安全信息
        /// </summary>
        /// <param name="controller"></param>
        /// <returns></returns>
        public static IPrincipal GetUser(this Controller controller)
        {
            return controller.User;
        }

        /// <summary>
        /// 当前用户的用户名
        /// </summary>
        /// <param name="controller"></param>
        /// <returns></returns>
        public static string GetUserName(this Controller controller)
        {
            return controller.User.Identity.Name;
        }

        /// <summary>
        /// 获取当前请求
        /// </summary>
        /// <param name="controller"></param>
        /// <returns></returns>
        public static HttpRequestBase GetRequestBase(this Controller controller)
        {
            return controller.Request;
        }

        /// <summary>
        /// 获取响应
        /// </summary>
        /// <param name="controller"></param>
        /// <returns></returns>
        public static HttpResponseBase GetResponseBase(this Controller controller)
        {
            return controller.Response;
        }

        /// <summary>
        /// 获取server工具基类
        /// </summary>
        /// <param name="controller"></param>
        /// <returns></returns>
        public static HttpServerUtilityBase GetServer(this Controller controller)
        {
            return controller.Server;
        }

        /// <summary>
        /// 获取form值 name是大小写不敏感的
        /// </summary>
        /// <param name="controller"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string GetFormString(this Controller controller,string name)
        {
            return controller.Request.Form[name];
        }

        /// <summary>
        /// 获取Query name是大小写不敏感的
        /// </summary>
        /// <param name="controller"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string GetQueryString(this Controller controller, string name)
        {
            return controller.Request.QueryString[name];
        }

        /// <summary>
        /// 获取viewdata key是大小写不敏感的
        /// </summary>
        /// <param name="controller"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static object GetViewData(this Controller controller, string key)
        {
            return controller.ViewData[key];
        }

        /// <summary>
        ///	TempData is similar to Session data, except that TempData values are marked for deletion when they are read,
        /// </summary>
        /// <param name="controller"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static object GetTempData(this Controller controller, string key)
        {
            return controller.TempData[key];
        }

        /// <summary>
        /// 设置ViewData值
        /// </summary>
        /// <param name="controller"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void SetViewData(this Controller controller, string key, string value)
        {
            controller.ViewData[key] = value;
        }

        /// <summary>
        /// TempData is similar to Session data, except that TempData values are marked for deletion when they are read
        /// </summary>
        /// <param name="controller"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void SetTempData(this Controller controller, string key, string value)
        {
            controller.TempData[key] = value;
        }
    }
}