using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lesson6_2.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        [Required(ErrorMessage = "Enter product name")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Login can not be less than 5 and exceed 10 characters")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Enter product price")]
        [Range(0.01, 100000000, ErrorMessage = "Product price can not be less than 0.01 and exceed 100000000 numbers")]
        public int Price { get; set; }
        [Required(ErrorMessage = "Enter product description")]
        [StringLength(600, MinimumLength = 5, ErrorMessage = "Login can not be less than 5 and exceed 600 characters")]
        public string Description { get; set; }
        public DateTime AddedDate { get; set; }
    }
}