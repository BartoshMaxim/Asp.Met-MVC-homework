using _002_SimpleAjaxApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _002_SimpleAjaxApplication.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            var data = OrdersDatabase.Orders;

            var customerList = data.Select(x => x.Customer
            ).Distinct().ToList();
            customerList.Insert(0, "All");
            ViewBag.Customer = customerList;

            var productList = data.Select(x => x.Product).Distinct().ToList();
            productList.Insert(0, "All");
            ViewBag.Product = productList;

            var minValue = data.Min(x => x.Quantity);
            ViewBag.Min = minValue;

            var maxValue = data.Max(x => x.Quantity);
            ViewBag.Max = maxValue;

            return View();
        }

        //[HttpPost]
        //public ActionResult Index(string id)
        //{
        //    // id - имя клиента, заказы которого необходимо выводить на странице.
        //    return View("Index", (object)id);
        //}

        public ActionResult OrdersData(int max, int min, string product, string customer)
        {
            var data = OrdersDatabase.Orders;
            if (!string.IsNullOrEmpty(product) && product != "All")
            {
                // выполняем выборку по свойству Customer если значение id не пустое и не равное "All"
                data = data.Where(e => e.Product == product);
            }

            if (!string.IsNullOrEmpty(customer) && customer != "All")
            {
                // выполняем выборку по свойству Customer если значение id не пустое и не равное "All"
                data = data.Where(e => e.Customer == customer);
            }

            data = data.Where(e => e.Quantity >= min && e.Quantity <= max);

            return PartialView(data);
        }

       
    }
}
