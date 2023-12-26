using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webshop2.Models
{
    internal class Delivery
    {
        public Delivery()
        {
            Orders = new HashSet<Order>();
        }
        public int Id { get; set; }

        public string? Name { get; set; }
        public double? Price { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
