using Lesson6_2.Filters;
using Lesson6_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebMatrix.WebData;

namespace Lesson6_2.Controllers
{
    [Authorize]
    [InitializeSimpleMembershipAttribure]
    public class AccountController : Controller
    {
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View("Login");
        }
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel loginModel)
        {
            string ReturnUrl = Request.UrlReferrer.Query;
            if (ModelState.IsValid && WebSecurity.Login(loginModel.Email, loginModel.Password, loginModel.RememberMe))
            {
                return RedirectToLocal(ReturnUrl);
            }
            ModelState.AddModelError("", "Email or password is incorrect");
            return View();
        }

        [AllowAnonymous]
        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Registration(RegistrationModel registrationModel, string returnUrl)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    IDictionary<string, object> values = new Dictionary<string, object>();
                    values["FirstName"] = registrationModel.FirstName;
                    values["LastName"] = registrationModel.LastName;
                    values["RegistrationDate"] = DateTime.Now;
                    WebSecurity.CreateUserAndAccount(registrationModel.Email, registrationModel.Password, values);
                    Roles.AddUserToRole(registrationModel.Email, "User");
                    WebSecurity.Login(registrationModel.Email, registrationModel.Password);

                    return RedirectToAction("Index", "Home");

                }
            }
            catch (MembershipCreateUserException e)
            {
                ModelState.AddModelError("", e);
            }
            return View();
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Logout()
        {
            WebSecurity.Logout();
            return RedirectToAction("Index", "Home");
        }
        #region Helpers
        private ActionResult RedirectToLocal(string currentUrl)
        {
            if (Url.IsLocalUrl(currentUrl))
            {
                return Redirect(currentUrl);
            }
            else
                return RedirectToAction("Index", "Home");
        }
        #endregion
    }
}
