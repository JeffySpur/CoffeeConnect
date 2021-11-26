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
    public class CustomerController : Controller
    {
        // GET: Customer

        private static CustomerService CreateCustomerService()
        {
            return new CustomerService();
        }
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

        public ActionResult Details(int id)
        {
            var svc = CreateCustomerService();
            var model = svc.GetCustomerById(id);
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateCustomerService();
            var detail = service.GetCustomerById(id);
            var model =
                new CustomerEdit
                {
                    CustomerId = detail.CustomerId,
                    FirstName = detail.FirstName,
                    LastName = detail.LastName
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CustomerEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.CustomerId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            var service = CreateCustomerService();

            if (service.UpdateCustomer(model))
            {
                TempData["SaveResult"] = " That Customer has been updated. ";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Customer could not be updated. ");
            return View(model);

        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateCustomerService();
            var model = svc.GetCustomerById(id);
            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteCustomer(int id)
        {
            var service = CreateCustomerService();
            service.DeleteCustomer(id);
            TempData["SaveResult"] = "Your Customer has been deleted";

            return RedirectToAction("Index");
        }


    }
}