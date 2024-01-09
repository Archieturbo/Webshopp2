using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webshop2.Models
{
    public class MyDbContext : DbContext
    {
        public DbSet<Supplier> Supplier { get; set; }
        
        public DbSet<Category> Category { get; set; }
        public DbSet<Product> Product { get; set; }

        public DbSet<Orderdetail> Orderdetail { get; set; }

        public DbSet<Delivery> Delivery { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Order> Order { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=Webshop2;Trusted_Connection=True;TrustServerCertificate=True");
        }

    }
    

}

