using System;
using System.Collections.Generic;

namespace APISuperMarket.Models
{
    public partial class UserChange
    {
        public int UserChangeId { get; set; }
        public int? AdminId { get; set; }
        public int? CustomerId { get; set; }
        public int? ChangeTypeId { get; set; }
        public string? ChangeDescription { get; set; }
        public DateTime? ChangeDate { get; set; }

        public virtual Customer? Admin { get; set; }
        public virtual ChangeType? ChangeType { get; set; }
        public virtual Customer? Customer { get; set; }
    }
}
