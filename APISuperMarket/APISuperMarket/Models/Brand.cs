using System;
using System.Collections.Generic;

namespace APISuperMarket.Models
{
    public partial class Brand
    {
        public Brand()
        {
            BrandChanges = new HashSet<BrandChange>();
            Products = new HashSet<Product>();
        }

        public int BrandId { get; set; }
        public string? BrandName { get; set; }
        public string? Description { get; set; }
        public int? NumberOfProducts { get; set; }
        public double? TotalStars { get; set; }
        public string? LogoBrandUrl { get; set; }
        public DateTime? CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }

        public virtual ICollection<BrandChange> BrandChanges { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
