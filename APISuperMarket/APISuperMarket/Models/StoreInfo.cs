using System;
using System.Collections.Generic;

namespace APISuperMarket.Models
{
    public partial class StoreInfo
    {
        public StoreInfo()
        {
            UiChanges = new HashSet<UiChange>();
        }

        public int StoreInfoId { get; set; }
        public string? StoreName { get; set; }
        public string? LogoUrl { get; set; }
        public string? BannerUrl { get; set; }
        public string? Hotline { get; set; }
        public string? AddressLine1 { get; set; }
        public string? Commune { get; set; }
        public string? District { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<UiChange> UiChanges { get; set; }
    }
}
