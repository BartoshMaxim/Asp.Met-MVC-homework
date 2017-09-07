using Lesson3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lesson3.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ShowTable()
        {
            IList<Product> products = new List<Product>();

            for (int i = 0; i < 10; i++)
                products.Add(new Product(i, "Product " + i, 10 * i));

            return PartialView("_Table", products);
        }
    }
}