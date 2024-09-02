using System;
using System.Collections.Generic;

namespace APISuperMarket.Models
{
    public partial class DiscountCode
    {
        public DiscountCode()
        {
            DiscountChanges = new HashSet<DiscountChange>();
            Orders = new HashSet<Order>();
        }

        public int DiscountCodeId { get; set; }
        public string? Code { get; set; }
        public string? Description { get; set; }
        public int? DiscountPercentage { get; set; }
        public double? DiscountAmount { get; set; }
        public DateTime? ValidFrom { get; set; }
        public DateTime? ValidTo { get; set; }
        public double? MinimumOrderAmount { get; set; }
        public int? MaxUsages { get; set; }
        public int? CurrentUsages { get; set; }
        public DateTime? CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }

        public virtual ICollection<DiscountChange> DiscountChanges { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
