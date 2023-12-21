using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webshop2.Models
{
    internal partial class OrderDetails
    {
        public OrderDetails()
        {
            shoppingCart = new HashSet<ShoppingCart>();
        }
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int ShoppingCartId { get; set; }
        public int ShippingId { get; set; }
        public int? Quantity { get; set; }
        public virtual Product product { get; set; }
        public virtual Order Order { get; set; }
        public virtual ICollection<ShoppingCart> shoppingCart { get; set; }


    }
}
