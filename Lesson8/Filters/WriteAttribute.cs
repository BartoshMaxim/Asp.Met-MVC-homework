using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lesson8.Filters
{
    public class WriteAttribute : ActionFilterAttribute
    {
        public Stopwatch timer;
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            timer = Stopwatch.StartNew();
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            timer.Stop();
            var fileName = Path.Combine(AppDomain.CurrentDomain.GetData("DataDirectory") as string, "Info.txt");
            using (System.IO.StreamWriter file =
           new System.IO.StreamWriter(fileName, true))
            {
                file.WriteLine(string.Format("Method: {0}; Time: {1}", filterContext.ActionDescriptor.ActionName, timer.Elapsed));
            }
        }
    }
}