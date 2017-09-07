using Lesson8.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lesson8.Controllers
{
    [WriteAttribute]
    public class HomeController : Controller
    {
        [WriteAttribute]
        public ActionResult Index()
        {
            return View();
        }
        [WriteAttribute]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        [WriteAttribute]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}