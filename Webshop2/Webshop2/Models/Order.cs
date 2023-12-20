using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webshop2.Models
{
    internal class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetails>();
            Customer = new HashSet<Customer>(); 
            Shipping = new HashSet<Shipping>();
        }
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public int ShippingId { get; set; }
        public DateTime? OrderDate { get; set; }
        public string? ShippingAdress { get; set; }
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
        public virtual ICollection<Customer> Customer {get; set; }
        public virtual ICollection<Shipping> Shipping { get; set; }


    }
}
