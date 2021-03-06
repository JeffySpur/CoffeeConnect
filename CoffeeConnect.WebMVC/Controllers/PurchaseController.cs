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
        public ActionResult Edit(int id)
        {
            var service = CreatePurchaseService();
            var detail = service.GetPurchaseById(id);
            var model =
                new PurchaseEdit
                {
                    PurchaseId = detail.PurchaseId,
                    CoffeeId = detail.CoffeeId,
                    CustomerId = detail.CustomerId,
                    CoffeeName = detail.CoffeeName,
                    LbsOfCoffee = detail.LbsOfCoffee
                    
                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PurchaseEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.PurchaseId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            var service = CreatePurchaseService();

            if (service.UpdatePurchase(model))
            {
                TempData["SaveResult"] = " That Purchase has been updated. ";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Purchase could not be updated. ");
            return View(model);

        }

        private PurchaseService CreatePurchaseService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PurchaseService(userId);
            return service;
        }
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreatePurchaseService();
            var model = svc.GetPurchaseById(id);
            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePurchase(int id)
        {
            var service = CreatePurchaseService();
            service.DeletePurchase(id);
            TempData["SaveResult"] = "Your Purchase has been deleted";

            return RedirectToAction("Index");
        }
    }
}