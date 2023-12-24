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
        
        public DbSet<Category> Category { get; set; }
         
        public DbSet<Product> Product { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=Webshop2;Trusted_Connection=True;TrustServerCertificate=True");
        }

    }

}

