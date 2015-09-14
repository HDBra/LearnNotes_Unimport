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


        [HttpPost]
        public ActionResult Index(Color color)
        {
            Color? oldColor = Session["color"] as Color?;
            if (oldColor != null)
            {
                Votes.ChangeVote(color, oldColor.Value);
            }
            else
            {
                Votes.RecordVote(color);
            }

            ViewBag.SelectedColor = Session["color"] = color;
            return View();
        }
    }
}