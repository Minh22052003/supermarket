using System;
using System.Collections.Generic;

namespace APISuperMarket.Models
{
    public partial class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int? OrderId { get; set; }
        public int? ProductId { get; set; }
        public int? Quantity { get; set; }
        public double? Price { get; set; }
        public double? TotalPrice { get; set; }
        public DateTime? CreateAt { get; set; }
        public DateTime? UpdateTime { get; set; }

        public virtual Order? Order { get; set; }
        public virtual Product? Product { get; set; }
    }
}
