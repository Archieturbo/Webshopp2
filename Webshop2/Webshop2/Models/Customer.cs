using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webshop2.Models
{
    public class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Adress { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
        public DateTime? Birthday { get; set; }
        public string?  Phone { get; set; }
        public string? Email { get; set; }
        public ICollection<Order> Orders { get; set; }



    }
}
