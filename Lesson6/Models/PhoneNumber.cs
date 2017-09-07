using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lesson6.Models
{
    public class PhoneNumber
    {
        public int CountryNumber { get; set; }
        public int CityNumber { get; set; }
        public int UserNumber { get; set; }

        public override string ToString()
        {
            return CountryNumber + " " + CityNumber + " " + UserNumber;
        }
    }
}