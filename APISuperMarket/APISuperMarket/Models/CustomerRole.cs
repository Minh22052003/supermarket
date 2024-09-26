using System;
using System.Collections.Generic;

namespace APISuperMarket.Models
{
    public partial class CustomerRole
    {
        public int CustomerRoleId { get; set; }
        public int? RoleId { get; set; }
        public int? CustomerId { get; set; }

        public virtual Customer? Customer { get; set; }
        public virtual Role? Role { get; set; }
    }
}
