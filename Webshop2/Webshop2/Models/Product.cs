using System;
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
            OrderDetails = new HashSet<OrderDetails>();
            Supplier = new HashSet<Supplier>();
            ProductCategory = new HashSet<ProductCategory>();
        }
        public int ProductId { get; set; }
        public string? Name { get; set; }
        public string? Color { get; set; }
        public double? Price { get; set; }
        public int? UnitsInStock { get; set; }
        public int SupplierId { get; set; }
        public int ProductCategoryId { get; set; }
        public ICollection<OrderDetails> OrderDetails { get; set; }
        public ICollection<Supplier> Supplier { get; set; }
        public ICollection<ProductCategory> ProductCategory { get; set; }

        public enum Size
        {
            Small,
            Medium,
            Large,
        }




    }
}
