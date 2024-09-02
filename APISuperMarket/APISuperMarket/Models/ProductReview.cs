using System;
using System.Collections.Generic;

namespace APISuperMarket.Models
{
    public partial class ProductReview
    {
        public ProductReview()
        {
            ReviewImages = new HashSet<ReviewImage>();
        }

        public int ProductReviewsId { get; set; }
        public double? Rating { get; set; }
        public string? Comment { get; set; }
        public int? ProductId { get; set; }
        public int? CustomerId { get; set; }
        public DateTime? CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }

        public virtual Customer? Customer { get; set; }
        public virtual Product? Product { get; set; }
        public virtual ICollection<ReviewImage> ReviewImages { get; set; }
    }
}
