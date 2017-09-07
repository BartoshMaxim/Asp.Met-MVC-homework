using Lesson6_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lesson6_2.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult Reports()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Reports(DateTime start, DateTime end)
        {
            DatabaseContext db = new DatabaseContext();
            List<Order> orders = db.Orders.ToList();
            var findOrders = orders.FindAll(x => (DateTime.Compare(x.OrderDate, start) >= 0 && DateTime.Compare(x.OrderDate, end) <= 0));
            return View(findOrders);
        }
        [Authorize]
        public ActionResult UserStatistics()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UserStatistics(int id)
        {
            DatabaseContext db = new DatabaseContext();
            List<User> orders = db.Users.ToList();
            var findUser = orders.Find(x => x.UserId == id);
            int cost = 0;
            if (findUser != null && findUser.Orders != null)
            {
                foreach (var order in findUser.Orders)
                {
                    cost += order.ProductCount * order.Product.Price;
                }

                ViewBag.Cost = cost;
            }
            else
                return View();
            return View(findUser.Orders);
        }

    }
}