using CoffeeConnect.Models;
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
            var model = new CoffeeListItem[0];
            return View(model);
        }
    }
}