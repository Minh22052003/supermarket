using System;
using System.Collections.Generic;

namespace APISuperMarket.Models
{
    public partial class AccCustomer
    {
        public int AccCustomerId { get; set; }
        public int? CustomerId { get; set; }
        public string? UserName { get; set; }
        public string? HashPass { get; set; }
        public string? AuthProvider { get; set; }
        public string? ProviderId { get; set; }
        public DateTime? DateCreation { get; set; }
        public int? StatusAccId { get; set; }

        public virtual Customer? Customer { get; set; }
        public virtual StatusAcc? StatusAcc { get; set; }
    }
}
