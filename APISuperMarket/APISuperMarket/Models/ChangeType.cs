using System;
using System.Collections.Generic;

namespace APISuperMarket.Models
{
    public partial class ChangeType
    {
        public ChangeType()
        {
            BrandChanges = new HashSet<BrandChange>();
            DiscountChanges = new HashSet<DiscountChange>();
            OrderChanges = new HashSet<OrderChange>();
            ProductChanges = new HashSet<ProductChange>();
            UiChanges = new HashSet<UiChange>();
            UserChanges = new HashSet<UserChange>();
        }

        public int ChangeTypeId { get; set; }
        public string? ChangeName { get; set; }

        public virtual ICollection<BrandChange> BrandChanges { get; set; }
        public virtual ICollection<DiscountChange> DiscountChanges { get; set; }
        public virtual ICollection<OrderChange> OrderChanges { get; set; }
        public virtual ICollection<ProductChange> ProductChanges { get; set; }
        public virtual ICollection<UiChange> UiChanges { get; set; }
        public virtual ICollection<UserChange> UserChanges { get; set; }
    }
}
