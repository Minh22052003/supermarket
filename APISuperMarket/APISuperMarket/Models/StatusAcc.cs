using System;
using System.Collections.Generic;

namespace APISuperMarket.Models
{
    public partial class StatusAcc
    {
        public StatusAcc()
        {
            AccCustomers = new HashSet<AccCustomer>();
        }

        public int StatusAccId { get; set; }
        public string? StatusAccName { get; set; }

        public virtual ICollection<AccCustomer> AccCustomers { get; set; }
    }
}
