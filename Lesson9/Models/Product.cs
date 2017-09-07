using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lesson9.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
    }

    public static class ProductDB
    {
        public static IEnumerable<Product> ProductCollections()
        {
            IList<Product> productList = new List<Product>();
            for (int i = 0; i < 15; i++)
            {
                productList.Add(new Product
                {
                    Id = i,
                    ProductName = "Product " + i
                }
                );
            }
            return productList;
        }
    }
}