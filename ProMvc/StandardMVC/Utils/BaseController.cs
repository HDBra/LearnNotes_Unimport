using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StandardMVC.Utils
{
    /// <summary>
    /// 积累Controller
    /// </summary>
    public class BaseController:Controller
    {
        /// <summary>
        /// 返回默认的View
        /// </summary>
        /// <returns></returns>
        public ActionResult BaseView()
        {
            return View();
        }

        /// <summary>
        /// 返回指定名的字View
        /// "~/Views/Example/Index.cshtml"指定全径路
        /// or "Index"指定当前目的录view 名称
        /// </summary>
        /// <param name="viewName"></param>
        /// <returns></returns>
        public ActionResult BaseView(string viewName)
        {
            return View(viewName);
        }

        /// <summary>
        /// 传递给页面一个model
        /// 在页面中使用@model type全限定，在View中使用Model来引用该强类型
        /// 也可以使用@using来引用命名空间
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult BaseView(Object model)
        {
            return View(model);
        }

        /// <summary>
        /// http not found
        /// </summary>
        /// <returns></returns>
        public ActionResult NotFound()
        {
            return HttpNotFound();
        }
        
    }
}