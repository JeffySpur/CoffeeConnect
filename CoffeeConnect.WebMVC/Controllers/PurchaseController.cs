using CoffeeConnect.Models;
using CoffeeConnect.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoffeeConnect.WebMVC.Controllers
{
    [Authorize]
    public class PurchaseController : Controller
    {

        // GET: Purchase
        public ActionResult Index()
        {

            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PurchaseService(userId);
            var model = service.GetPurchases();
            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PurchaseCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreatePurchaseService();

            if (service.CreatePurchase(model))
            {
                TempData["SaveResult"] = "Your purchase has gone through. ";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "Sorry, the purchase has not gone through. ");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreatePurchaseService();
            var model = svc.GetPurchaseById(id);
            return View(model);
        }

        private PurchaseService CreatePurchaseService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PurchaseService(userId);
            return service;
        }
    }
}