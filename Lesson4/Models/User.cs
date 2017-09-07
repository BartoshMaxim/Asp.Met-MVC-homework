using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lesson4.Models
{
    public class User
    {
        public string Login { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public User()
        {

        }

        public User(string login, string email, string password)
        {
            Login = login;
            Email = email;
            Password = password;
        }

        public override string ToString()
        {
            return Login;
        }
    }
}