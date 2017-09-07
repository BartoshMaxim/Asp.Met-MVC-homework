using Lesson6_2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using WebMatrix.WebData;
using System.Web.Mvc;
using System.Web.Security;
using System.Threading;

namespace Lesson6_2.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class InitializeSimpleMembershipAttribure : ActionFilterAttribute
    {
        private static SimpleMembershipInitializer _initializer;

        private static object _initializerLock = new object();

        private static bool _isInitializer;

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            LazyInitializer.EnsureInitialized(ref _initializer, ref _isInitializer, ref _initializerLock);
        }

        private class SimpleMembershipInitializer
        {
            public SimpleMembershipInitializer()
            {
                Database.SetInitializer<DatabaseContext>(null);
                using (var context = new DatabaseContext())
                {
                    if (!context.Database.Exists())
                    {
                        // Создание базы данных SimpleMembership без применения миграции Entity Framework
                        ((IObjectContextAdapter)context).ObjectContext.CreateDatabase();
                    }


                    WebSecurity.InitializeDatabaseConnection("DatabaseContext", "User", "UserId", "Email", true);

                    SimpleRoleProvider roles = Roles.Provider as SimpleRoleProvider;
                    SimpleMembershipProvider membership = Membership.Provider as SimpleMembershipProvider;

                    string admin = "Admin";
                    string user = "User";
                    if (!roles.RoleExists(admin))
                    {
                        roles.CreateRole(admin);
                    }

                    if (!roles.RoleExists(user))
                    {
                        roles.CreateRole(user);
                    }

                   

                    // Поиск пользователя с логином admin
                    if (membership.GetUser("admin@admin.com", false) == null)
                    {
                        IDictionary<string, object> values = new Dictionary<string, object>();
                        values["FirstName"]= "Maxim";
                        values["LastName"] = "Bartosh";
                        values["RegistrationDate"] = DateTime.Now;
                        membership.CreateUserAndAccount("admin@admin.com", "qwe123", values); // создание пользователя
                        roles.AddUsersToRoles(new[] { "admin@admin.com" }, new[] { "Admin" }); // установка роли для пользователя
                    }
                }
            }
        }
    }
}