using System;
using System.Collections.Generic;

namespace APISuperMarket.Models
{
    public partial class BrandChange
    {
        public int BrandChangeId { get; set; }
        public int? BrandId { get; set; }
        public int? CustomerId { get; set; }
        public int? ChangeTypeId { get; set; }
        public string? ChangeDescription { get; set; }
        public DateTime? ChangeDate { get; set; }

        public virtual Brand? Brand { get; set; }
        public virtual ChangeType? ChangeType { get; set; }
        public virtual Customer? Customer { get; set; }
    }
}
