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
            if (!ModelState.IsValid)
            { 
            return View(model);
            }
            var service = new CoffeeService();

            service.CreateCoffee(model);
            return RedirectToAction("Index");
        }
    }
}