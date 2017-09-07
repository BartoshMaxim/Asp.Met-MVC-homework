using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lesson4_02.Models
{
    public class HomeController : Controller
    {
       
        public ActionResult Index(string id)
        {
            return View((object)id);
        }
    }
}