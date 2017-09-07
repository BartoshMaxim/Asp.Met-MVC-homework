using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lesson6_2.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Enter user email")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Not correct email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegistrationModel
    {
        [Required(ErrorMessage = "Enter first name")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "FirstName can not be less than 5 and exceed 10 characters")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Enter last name")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "LastName can not be less than 5 and exceed 10 characters")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Enter user email")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Not correct email")]
        public string Email { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [Compare("Password", ErrorMessage = "The new password and confirmation password do not match.")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}