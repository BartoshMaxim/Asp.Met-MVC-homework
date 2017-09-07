using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lesson4.Instructions
{
    public static class ErrorInstruction
    {
        public static MvcHtmlString ErrorHelper(this HtmlHelper helper, string error)
        {
            TagBuilder errorTag = new TagBuilder("p");
            errorTag.Attributes["style"] = "color:red";
            errorTag.InnerHtml = error;
            return new MvcHtmlString(errorTag.ToString());

        }
    }
}