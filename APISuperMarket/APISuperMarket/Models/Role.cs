using System;
using System.Collections.Generic;

namespace APISuperMarket.Models
{
    public partial class Role
    {
        public Role()
        {
            CustomerRoles = new HashSet<CustomerRole>();
        }

        public int RoleId { get; set; }
        public string? RoleName { get; set; }

        public virtual ICollection<CustomerRole> CustomerRoles { get; set; }
    }
}
