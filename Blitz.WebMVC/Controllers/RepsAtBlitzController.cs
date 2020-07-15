using SalesBlitz.Models.RepsAtBlitzModels;
using SalesBlitz.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages.Instrumentation;

namespace Blitz.WebMVC.Controllers
{
    public class RepsAtBlitzController : Controller
    {
        // GET: RepsAtBlitz
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Create(RepAtBlitzCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateRepAtBlitzService();

            if (service.CreateRepAtBlitz())
            {
                TempData["SaveResult"] = "Your RepsAtBlitz was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "RepsAtBlitz could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateRepAtBlitzService();
            var model = svc.GetRepAtBlitzById(id);

            return View(model);
        }
        public RepsAtBlitzService CreateRepAtBlitzService()
        {
            
            var service = new RepsAtBlitzService();
            return service;
        }

        public ActionResult Edit(int id)
        {
            var service = CreateRepAtBlitzService();
            var detail = service.GetRepAtBlitzById(id);
            var model =
                new RepAtBlitzEdit
                {
                    //BlitzId = detail.BlitzId,
                    //RepId = detail.RepId,
                    HomeArea = detail.HomeArea,
                    RepName = detail.RepName,
                    Position = detail.Position
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, RepAtBlitzEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.BlitzId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateRepAtBlitzService();

            if (service.UpdateRepAtBlitz(model))
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
            var svc = CreateRepAtBlitzService();
            var model = svc.GetRepAtBlitzById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]

        public ActionResult DeletePost(int id)
        {
            var service = CreateRepAtBlitzService();

            service.DeleteRepAtBlitz(id);

            TempData["SaveResult"] = "Your RepsAtBlitz was deleted";

            return RedirectToAction("Index");
        }
    }
}
