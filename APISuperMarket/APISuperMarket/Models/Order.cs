using System;
using System.Collections.Generic;

namespace APISuperMarket.Models
{
    public partial class Order
    {
        public Order()
        {
            BankTransfers = new HashSet<BankTransfer>();
            OrderChanges = new HashSet<OrderChange>();
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int OrderId { get; set; }
        public int? CustomerId { get; set; }
        public int? OrderStatusId { get; set; }
        public int? DiscountCodeId { get; set; }
        public double? TotalAmoint { get; set; }
        public double? DiscountAmount { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? UpdateTime { get; set; }
        public int? AddressId { get; set; }

        public virtual Address? Address { get; set; }
        public virtual Customer? Customer { get; set; }
        public virtual DiscountCode? DiscountCode { get; set; }
        public virtual OrderStatus? OrderStatus { get; set; }
        public virtual ICollection<BankTransfer> BankTransfers { get; set; }
        public virtual ICollection<OrderChange> OrderChanges { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
