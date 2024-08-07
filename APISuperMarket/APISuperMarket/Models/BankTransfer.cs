using System;
using System.Collections.Generic;

namespace APISuperMarket.Models
{
    public partial class BankTransfer
    {
        public int BankTransferId { get; set; }
        public int? OrderId { get; set; }
        public string? BankName { get; set; }
        public double? AccountNumber { get; set; }
        public string? AccountName { get; set; }
        public double? Amount { get; set; }
        public DateTime? TransferDate { get; set; }
        public string? Status { get; set; }
        public DateTime? CreateAt { get; set; }
        public DateTime? UpdateTime { get; set; }

        public virtual Order? Order { get; set; }
    }
}
