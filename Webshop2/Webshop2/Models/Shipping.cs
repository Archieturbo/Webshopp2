using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webshop2.Models
{
    internal partial class Shipping
    {
        public int Id { get; set; }
        public string? CompanyName { get; set; }
        public double? Price { get; set; }
        public virtual Order Order { get; set; }







    }
}
