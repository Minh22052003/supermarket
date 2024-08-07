using System;
using System.Collections.Generic;

namespace APISuperMarket.Models
{
    public partial class UiChange
    {
        public int UiChangeId { get; set; }
        public int? StoreInfoId { get; set; }
        public int? CustomerId { get; set; }
        public int? ChangeTypeId { get; set; }
        public string? ChangeDescription { get; set; }
        public DateTime? ChangeDate { get; set; }

        public virtual ChangeType? ChangeType { get; set; }
        public virtual Customer? Customer { get; set; }
        public virtual StoreInfo? StoreInfo { get; set; }
    }
}
