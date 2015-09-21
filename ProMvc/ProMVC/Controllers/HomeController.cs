using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProMVC.Models;

namespace ProMVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 无法找到资源。 
        /// HTTP 404。
        /// </summary>
        /// <returns></returns>
        public ActionResult Test()
        {
            return HttpNotFound();
        }
    }
}