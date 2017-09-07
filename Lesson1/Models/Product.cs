using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lesson1.Models
{
    public class Product
    {
        public int Id { get; }
        public string Name { get; }
        public string Price { get; }
        public string Description { get; }

        public Product(int id, string name, string price, string description)
        {
            Id = id;
            Name = name;
            Price = price;
            Description = description;
        }
    }
}