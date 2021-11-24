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
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            var customerservice = new CustomerService();
            var customers = customerservice.GetCustomers();
            return View(customers);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CustomerCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateCustomerService();

            if (service.CreateCustomer(model))
            {
                TempData["SaveResult"] = "That Customer has been added. ";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "Sorry, Customer has not been added. ");

            return View(model);
        }

        private static CustomerService CreateCustomerService()
        {
            return new CustomerService();
        }
    }
}