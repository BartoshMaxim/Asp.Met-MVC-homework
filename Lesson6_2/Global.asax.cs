using System;
using System.Collections.Generic;
using System.Linq;
using Lesson6_2.Models;
using System.Web.Mvc;
using System.Web.Routing;
using Lesson6_2.App_Start;

namespace Lesson6_2
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            ModelBinders.Binders.Add(typeof(User), new UserBinder());

            RouteConfig.RegisterRoutes(RouteTable.Routes);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
        }
    }
}
