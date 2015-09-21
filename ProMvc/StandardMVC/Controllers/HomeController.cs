using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StandardMVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 来自query string 或者 form post名为param的参数
        ///  /home/browse?param=lily
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public string Browse(string param)
        {
            //将字符串转换为html编码字符串，防止注入html或者js
            return "hello from " + HttpUtility.HtmlEncode(param);
        }

        /// <summary>
        /// asp.net mvc 路由默认将action后的部分命为名ID，如果action 中有一个名为id的参数，mcv将其赋给id
        /// /home/deatlis/id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string Details(string id/* int id */)
        {
            return "Hello " + HttpUtility.HtmlEncode(id);
        }
        
    }
}