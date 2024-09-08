using System;
using System.Collections.Generic;

namespace APISuperMarket.Models
{
    public partial class Cart
    {
        public Cart()
        {
            CartProducts = new HashSet<CartProduct>();
        }

        public int CartId { get; set; }
        public int? CustomerId { get; set; }

        public virtual Customer? Customer { get; set; }
        public virtual ICollection<CartProduct> CartProducts { get; set; }
    }
}
