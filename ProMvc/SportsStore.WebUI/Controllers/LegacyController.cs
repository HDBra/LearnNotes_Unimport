using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsStore.WebUI.Controllers
{
    public class LegacyController : Controller
    {
        //
        // GET: /Legacy/

        public ActionResult GetLegacyURL(String legacyURL)
        {
            return View((object)legacyURL);
        }

    }
}
