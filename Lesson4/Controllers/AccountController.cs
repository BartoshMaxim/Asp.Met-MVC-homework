using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using Lesson4.Models;
using System.Text.RegularExpressions;

namespace Lesson4.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View("Login");
        }

        public ActionResult Login()
        {
            if (Session["User"] != null)
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            return View();
        }

        public ActionResult CheckUser(LoginModel loginModel)
        {

            string path = Server.MapPath("~/App_Data/users.xml");
            UserList users = UserList.Load(path);
            if (users != null)
            {
                var user = users.Check(loginModel.Login, loginModel.Password);
                if (user != null)
                {
                    Session.Add("User", user);

                    return RedirectToRoute(new { controller = "Home", action = "Index" });
                }

            }
            ViewBag.Error = "Login or password incorrect";
            return View("Login");
        }



        public ActionResult Registration()
        {
            if (Session["User"] != null)
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            return View();
        }

        [HttpPost]
        public ActionResult Registration(RegistrationModel registrationModel)
        {
            string path = Server.MapPath("~/App_Data/users.xml");

            string error = string.Empty;
            if (registrationModel.Password.Length < 5)
                error += "Password must be long that 4 symbols\n";
            if (registrationModel.Password != registrationModel.Repassword)
                error += "Passwords do not match\n";
            if (registrationModel.Login == string.Empty)
                error += "Enter Login\n";
            if (registrationModel.Email == string.Empty)
                error += "Enter Email\n";

            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(registrationModel.Email);


            if (!match.Success)
            {
                error += "Email not correct\n";
            }

            if (error != string.Empty)
            {
                ViewBag.Error = error;
                return View();
            }
            UserList users = UserList.Load(path);
            if (users != null)
            {
                foreach (var user in users.Users)
                {
                    if (user.Login == registrationModel.Login)
                    {
                        error += "Login already exists";
                    }

                    if (user.Email == registrationModel.Email)
                    {
                        error += "Email already exists";
                    }
                }
            }
            else
                users = new UserList();

            if (error == string.Empty)
            {
                var user = new User(registrationModel.Login, registrationModel.Email, registrationModel.Password);
                users.Users.Add(user);
                users.Save(path);
                Session.Add("User", user);

                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            else
                ViewBag.Error = error;

            return View();
        }
    }
}