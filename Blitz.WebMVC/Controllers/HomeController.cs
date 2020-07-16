using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blitz.WebMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "SALES BLITZ, is used to organize group face to face calls on an individual territory to give that market a quick boost. It manages getting the territories sales funnel full, by blanketing a market with in person calls. Ideally used as a 1-2 day event. This program assist a group to pay it forward by helping out a team member. ";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Sales Solutions Group LLC";

            return View();
        }
    }
}