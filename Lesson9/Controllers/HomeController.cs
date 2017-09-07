using Lesson9.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lesson9.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ProductView(int page)
        {
            var productList = ProductDB.ProductCollections();

            if (page == 1)
            {
                productList = productList.Where(x => x.Id < page * 5);
            }
            else
            {
                productList = productList.Where(x => (x.Id >= (page * 5 - 5)) && x.Id < page * 5);
            }
            return PartialView(productList);
        }
    }
}