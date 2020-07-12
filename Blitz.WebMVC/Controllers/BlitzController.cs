using Microsoft.AspNet.Identity;
using SalesBlitz.Data;
using SalesBlitz.Models;
using SalesBlitz.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blitz.WebMVC.Controllers
{
    [Authorize]
    public class BlitzController : Controller
    {
        // GET: Blitz
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new BlitzService(userId);
            var model = service.GetBlitzes();

            return View(model);

        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BlitzCreate model)
        {
            if (ModelState.IsValid)
            {

            }
            return View(model);
        }
    }
}