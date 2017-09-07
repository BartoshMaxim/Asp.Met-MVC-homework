using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lesson3.Models
{
    public class Product
    {
        public int ID { get; }
        public string Name { get; }
        public int Price { get; }
        public DateTime CreatedDate { get; }

        public Product(int id, string name, int price)
        {
            ID = id;
            Name = name;
            Price = price;
            CreatedDate = DateTime.Now;
        }
    }
}