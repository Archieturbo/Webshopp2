﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webshop2.Models
{
    internal class Product
    {
        public Product()
        {
            Categories = new HashSet<Category>();
            Orderdetails = new HashSet<Orderdetail>();

        }
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Color { get; set; }
        public int? SupplierId { get; set; }
        public int? UnitsInStock { get; set; }
        public double? Price { get; set; }
        public ICollection<Category> Categories { get; set; }
        public Supplier? Supplier { get; set; }
        public ICollection<Orderdetail> Orderdetails { get; set; }



    }
}
