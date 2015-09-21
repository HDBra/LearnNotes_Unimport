using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProMVC.Controllers
{
    public class StoreController : Controller
    {
        // GET: Store
        public string Index()
        {
            return "Hello from index";
        }

        public string Browse()
        {
            return "Hello from browse";
        }

        public string Details()
        {
            return "Hello from details";
        }

    }
}