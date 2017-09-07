using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lesson6_2.Models
{
    public class Order
    {
        [Required(ErrorMessage = "Choose OrderId")]
        public int OrderId { get; set; }
        [Required(ErrorMessage = "Choose UserId")]
        public int UserId { get; set; }
        public int ProductId { get; set; }
        [Required(ErrorMessage = "Enter product count")]
        [Range(1, 1000, ErrorMessage = "Enter product count greater then 0")]
        public int ProductCount { get; set; }
        public DateTime OrderDate { get; set; }
        public virtual Product Product { get; set; }
        public virtual User User { get; set; }
    }
}