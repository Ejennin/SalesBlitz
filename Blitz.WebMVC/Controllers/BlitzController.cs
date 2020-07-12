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
            if (!ModelState.IsValid) return View(model);

            var service = CreateBlitzService();

            if (service.CreateBlitz(model))
            {
                TempData["SaveResult"] = "Your Blitz was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Blitz could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateBlitzService();
            var model = svc.GetBlitzById(id);

            return View(model);
        }
        public BlitzService CreateBlitzService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new BlitzService(userId);
            return service;
        }

        public ActionResult Edit(int id)
        {
            var service = CreateBlitzService();
            var detail = service.GetBlitzById(id);
            var model =
                new BlitzEdit
                {
                    BlitzId = detail.BlitzId,
                    Name = detail.Name,
                    Location = detail.Location,
                    Date  = detail.Date
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, BlitzEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.BlitzId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateBlitzService();

            if (service.UpdateBlitz(model))
            {
                TempData["SaveResult"] = "Your Blitz was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your Blitz could not be updated.");
            return View(model);
        }
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateBlitzService();
            var model = svc.GetBlitzById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateBlitzService();

            service.DeleteBlitz(id);

            TempData["SaveResult"] = "Your Blitz was deleted";

            return RedirectToAction("Index");
        }
    }
}