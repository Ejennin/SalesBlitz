using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Exchange.WebServices.Data;
using SalesBlitz.Models.RepsModels;
using SalesReps.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rep.WebMVC.Controllers
{
    public class RepController : Controller
    {
        // GET: Rep
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        
        public ActionResult Create(RepCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateRepService();

            if (service.CreateReps(model))
            {
                TempData["SaveResult"] = "Your Rep was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Rep could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateRepService();
            var model = svc.GetRepById( id);

            return View(model);
        }
        public RepsService CreateRepService()
        {

            var service = new RepsService();
            return service;
        }

        public ActionResult Edit(int id)
        {
            var service = CreateRepService();
            var detail = service.GetRepById(id);
            var model =
                new RepEdit
                {
                    RepId = detail.RepId,
                    RepName = detail.RepName,
                    Position = detail.Position,
                    
                };
            return View(model);
        }

        [HttpPost]
        
        public ActionResult Edit(int id, RepEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.RepId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateRepService();

            if (service.UpdateReps(model))
            {
                TempData["SaveResult"] = "Your Rep was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your Rep could not be updated.");
            return View(model);
        }
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateRepService();
            var model = svc.GetRepById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]

        public ActionResult DeletePost(int id)
        {
            var service = CreateRepService();

            service.DeleteReps(id);

            TempData["SaveResult"] = "Your Rep was deleted";

            return RedirectToAction("Index");
        }
    }
}