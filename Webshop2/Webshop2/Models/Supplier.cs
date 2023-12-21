using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webshop2.Models
{
    internal partial class Supplier
    {
        public int Id { get; set; }

        public string? CompanyName { get; set; }

        public string? Country { get; set; }

        public string? City { get; set; }

        public string? Address { get; set; }

        public string? Phone { get; set; }
        public virtual ICollection<Product> product { get; set; }

    }
}
