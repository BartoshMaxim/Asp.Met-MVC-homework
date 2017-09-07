using System;
using System.Collections.Generic;
using System.Linq;
using Lesson6_2.Models;
using System.Web.Mvc;

namespace Lesson6_2
{
    public class UserBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            User user = (User)bindingContext.Model ?? new User();
            var hasPrefix = bindingContext.ValueProvider.ContainsPrefix(bindingContext.ModelName);


            string searchPrefix = hasPrefix ? bindingContext.ModelName + "." : "";
            
            user.FirstName = GetValue(bindingContext, searchPrefix, "FirstName");
            user.LastName = GetValue(bindingContext, searchPrefix, "LastName");
            user.Email = GetValue(bindingContext, searchPrefix, "Email");

            return user;
        }

        private string GetValue(ModelBindingContext bindingContext, string prefix, string key)
        {
            ValueProviderResult vpr = bindingContext.ValueProvider.GetValue(prefix + key);
            return vpr == null ? null : vpr.AttemptedValue;
        }
    }
}