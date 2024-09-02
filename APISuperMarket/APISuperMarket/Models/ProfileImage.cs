using System;
using System.Collections.Generic;

namespace APISuperMarket.Models
{
    public partial class ProfileImage
    {
        public ProfileImage()
        {
            Customers = new HashSet<Customer>();
        }

        public int ProfileImageId { get; set; }
        public string? ImageUrl { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
    }
}
