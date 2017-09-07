using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace Lesson6_2.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() 
            : base("DatabaseContext")
        {
        }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
                
    }
}