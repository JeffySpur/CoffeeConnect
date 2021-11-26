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
            var purchaseservice = new PurchaseService();
            var purchases = purchaseservice.GetCustomers();
            return View(purchases);
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
    }
}