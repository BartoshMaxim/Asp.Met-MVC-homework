using Lesson5_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lesson5_2.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            CaclModel calc = new CaclModel();
            return View(calc);
        }

        [HttpPost]
        public ActionResult Index(CaclModel calc, string submit)
        {
            int result = 0;
            string error = "";

            switch (submit)
            {
                case "+":
                    result = calc.X + calc.Y;
                    break;
                case "-":
                    result = calc.X - calc.Y;
                    break;
                case "*":
                    result = calc.X * calc.Y;
                    break;
                case "/":
                    if (calc.Y == 0)
                    {
                        error += "you can not divide by 0";
                    }
                    else
                        result = calc.X / calc.Y;
                    break;
                default:
                    break;
            }
            if (error != "")
                ViewBag.Error = error;
            else
                ViewBag.Result = result;
            return View(calc);
        }
    }
}