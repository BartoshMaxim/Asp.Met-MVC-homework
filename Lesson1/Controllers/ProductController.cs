using Lesson1.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lesson1.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult List()
        {
            List<Product> products = new List<Product>();
            products.Add(new Product(0,"Bookeye 1", "1000$", "First bookeye"));
            products.Add(new Product(0, "Bookeye 2", "2000$", "Second bookeye"));
            products.Add(new Product(0, "Bookeye 3r2", "6000$", "Trird bookeye"));
            products.Add(new Product(0, "Bookeye 4v1", "10000$", "The biggest bookeye"));
            return View(products);
        }
    }
}