using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webshop2.Models
{
    internal class ProductCategory
    {
        public int Id { get; set; }
        public string? CategoryName { get; set; }
        public virtual ICollection<Product> product { get; set; }




    }
}
