using Lesson6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lesson6.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            User user = new User
            {
                Name = "Maxim",
                Phone = new PhoneNumber { CountryNumber = 123, CityNumber = 123, UserNumber = 123 }
            };
            return View(user);
        }
    }
}