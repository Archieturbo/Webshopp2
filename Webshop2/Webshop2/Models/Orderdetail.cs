using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webshop2.Models
{
    public class Orderdetail
    {
        public int Id { get; set; }

        public int? OrderId { get; set; }

        public int? ProductId { get; set; }
        public int? Quantity { get; set; }

        public int? DeliveryID { get; set; }
        public decimal? Price { get; set; }
        public Order? Order { get; set; }
        public Product? Product { get; set; }

        public Delivery? Shipping { get; set; }

    }
}
