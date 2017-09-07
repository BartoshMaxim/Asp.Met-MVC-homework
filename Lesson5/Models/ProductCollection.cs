using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lesson5.Models
{
    public class ProductCollection
    {
        private List<Product> _products;
        public List<Product> Products
        {
            get
            {
                _products = new List<Product>();
                for (int i = 0; i < 5; i++)
                    _products.Add(new Product
                    {
                        Id = i,
                        Name = "Product " + i,
                        Price = 10 * i,
                        Description = "Description product " + i
                    });
                return _products;
            }
        }
    }
}