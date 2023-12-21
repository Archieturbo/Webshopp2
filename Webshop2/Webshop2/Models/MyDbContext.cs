using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webshop2.Models
{
    internal class MyDbContext : DbContext
    {
        public DbSet<Supplier> Supplier { get; set; }
        public DbSet<ShoppingCart> ShoppingCart { get; set; }
        public DbSet<ProductCategory> ProductCategory { get; set; }
        public DbSet<Shipping> Shipping { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Product> Product { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=Webshop2;Trusted_Connection=True;TrustServerCertificate=True");
        }

    }

}

