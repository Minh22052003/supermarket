using System;
using System.Collections.Generic;

namespace APISuperMarket.Models
{
    public partial class RolePermission
    {
        public int? PermissionId { get; set; }
        public int? RoleId { get; set; }

        public virtual Permission? Permission { get; set; }
        public virtual Role? Role { get; set; }
    }
}
