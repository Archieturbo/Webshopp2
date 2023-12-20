using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webshop2.Models
{
    internal partial class Customer
    {

        public int CustomerId { get; set; }
        public string? Name { get; set; }

        public DateTime? BirthDate { get; set; }
        public string? Adress { get; set; }

        public string? Country { get; set; }

        public string? City { get; set; }

        public string? Street { get; set; }

        public string? Phone { get; set; }

        public string? Email { get; set; }

        public virtual Order order { get; set; }

    }
}
