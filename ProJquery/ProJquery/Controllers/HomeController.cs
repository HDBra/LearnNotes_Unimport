﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProJquery.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Css()
        {
            return View();
        }

        public ActionResult Standard()
        {
            return View();
        }

        public ActionResult Internel()
        {
            return View();
        }
    }
}
