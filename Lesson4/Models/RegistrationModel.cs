using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lesson4.Models
{
    public class RegistrationModel
    {
        public string Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Repassword { get; set; }
    }
}