using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Lesson6_2.Models
{
    [Table("User")]
    public class User
    {
        
        public int UserId { get; set; }

        [Required(ErrorMessage = "Enter first name")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "FirstName can not be less than 5 and exceed 10 characters")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Enter last name")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "LastName can not be less than 5 and exceed 10 characters")]
        public string LastName { get; set; }
        
        public DateTime RegistrationDate { get; set; }

        [Required(ErrorMessage = "Enter user email")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage ="Not correct email")]
        [Index("Email", IsUnique = true)]
        public string Email { get; set; }

        public virtual List<Order> Orders { get; set; }
    }
}