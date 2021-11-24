using CoffeeConnect.Data;
using CoffeeConnect.Models;
using CoffeeConnect.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoffeeConnect.WebMVC.Controllers
{
    [Authorize]
    public class CoffeeController : Controller
    {
        private static CoffeeService CreateCoffeeService()
        {
            return new CoffeeService();
        }

        // GET: Coffee
        public ActionResult Index()
        {
            var coffeeService = new CoffeeService();
            var coffees = coffeeService.GetCoffees();
            return View(coffees);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CoffeeCreate model)
        {
            if (!ModelState.IsValid) return View(model);
               
                 var service = CreateCoffeeService();
               
            if (service.CreateCoffee(model))
            {
                TempData["SaveResult"] = "Your Coffee has been added. ";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "Sorry, the coffee has not been added. ");
            
                return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateCoffeeService();
            var model = svc.GetCoffeeById(id);
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateCoffeeService();
            var detail = service.GetCoffeeById(id);
            var model =
                new CoffeeEdit
                {
                    CoffeeId = detail.CoffeeId,
                    CoffeeDescription = detail.CoffeeDescription,
                    PricePerPound = detail.PricePerPound
                };
            return View(model);
        }


            


    }
}