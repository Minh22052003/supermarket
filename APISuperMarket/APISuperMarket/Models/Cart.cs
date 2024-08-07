using System;
using System.Collections.Generic;

namespace APISuperMarket.Models
{
    public partial class Cart
    {
        public int CartId { get; set; }
        public int? CustomerId { get; set; }

        public virtual Customer? Customer { get; set; }
    }
}
