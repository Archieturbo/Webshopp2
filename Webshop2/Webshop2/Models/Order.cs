using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webshop2.Models
{
    public class Order
    {
        public Order()
        {
            Orderdetails = new HashSet<Orderdetail>();
        }
        public int Id { get; set; }
        public int? CustomerId { get; set; }
        public DateTime? OrderDate { get; set; }
        public string? Shipaddress { get; set; }
        public int? DeliveryId { get; set; }
        public Customer? Customer { get; set; }
        public Delivery? Delivery { get; set; }
        public ICollection<Orderdetail> Orderdetails { get; set; }


       


    }
}
