using System;
using System.Collections.Generic;

namespace APISuperMarket.Models
{
    public partial class BankAccount
    {
        public int BankAccountId { get; set; }
        public int? CustomerId { get; set; }
        public string? BankName { get; set; }
        public string? AccountHolderName { get; set; }
        public double? AccountNumber { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Customer? Customer { get; set; }
    }
}
