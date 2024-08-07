using System;
using System.Collections.Generic;

namespace APISuperMarket.Models
{
    public partial class Gender
    {
        public Gender()
        {
            Customers = new HashSet<Customer>();
        }

        public int GenderId { get; set; }
        public string? GenderName { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
    }
}
