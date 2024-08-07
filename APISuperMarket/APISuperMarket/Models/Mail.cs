using System;
using System.Collections.Generic;

namespace APISuperMarket.Models
{
    public partial class Mail
    {
        public Mail()
        {
            Customers = new HashSet<Customer>();
        }

        public int MailId { get; set; }
        public string? EmailAddress { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
    }
}
