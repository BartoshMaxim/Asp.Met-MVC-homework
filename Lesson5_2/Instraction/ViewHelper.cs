using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lesson5_2.Instraction
{
    public static class ViewHelper
    {
        public static MvcHtmlString ErrorHelper(this HtmlHelper helper, string error)
        {
            if (error != "")
            {
                TagBuilder errorBuider = new TagBuilder("p");
                errorBuider.InnerHtml = error;
                errorBuider.Attributes["style"] = "color:red";
                return new MvcHtmlString(errorBuider.ToString());
            }
            return null;
        }
        
        public static MvcHtmlString ResultHelper(this HtmlHelper helper, int result)
        {
            TagBuilder resultBuilder = new TagBuilder("p");
            resultBuilder.InnerHtml =  "Result = " + result.ToString();
            return new MvcHtmlString(resultBuilder.ToString());
        }
    }
}