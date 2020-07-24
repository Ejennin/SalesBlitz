using Microsoft.AspNet.Identity;
using SalesBlitz.Models.LeadModels;
using SalesLead.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lead.WebMVC.Controllers
{
    public class LeadController : Controller
    {
        // GET: Lead
        public ActionResult Index()
        {
            var LeadId = Guid.Parse(User.Identity.GetUserId());
            var service = new LeadService(LeadId);
            var model = service.GetLead();

            return View(model);

        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LeadCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateLeadService();

            if (service.CreateLead(model))
            {
                TempData["SaveResult"] = "Your Lead was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Lead could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateLeadService();
            var model = svc.GetLeadById(id);

            return View(model);
        }
        public LeadService CreateLeadService()
        {
            var LeadId = Guid.Parse(User.Identity.GetUserId());
            var service = new LeadService(LeadId);
            return service;
        }

        public ActionResult Edit(int id)
        {
            var service = CreateLeadService();
            var detail = service.GetLeadById(id);
            var model =
                new LeadEdit
                {
                    LeadId = detail.LeadId,
                    Content = detail.Content,
                    Status = detail.Status,
                    
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, LeadEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.LeadId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateLeadService();

            if (service.UpdateLead(model))
            {
                TempData["SaveResult"] = "Your Lead was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your Lead could not be updated.");
            return View(model);
        }
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateLeadService();
            var model = svc.GetLeadById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]

        public ActionResult DeletePost(int id)
        {
            var service = CreateLeadService();

            service.DeleteLead(id);

            TempData["SaveResult"] = "Your Lead was deleted";

            return RedirectToAction("Index");
        }
    }
}