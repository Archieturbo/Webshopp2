using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webshop2.Models
{
    internal partial class ShoppingCart
    {
        public int ShoppingCartId { get; set; }
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
        public int OrderId { get; set; }
        public virtual OrderDetails OrderDetails { get; set; }

    }
}
