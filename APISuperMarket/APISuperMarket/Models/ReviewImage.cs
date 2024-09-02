using System;
using System.Collections.Generic;

namespace APISuperMarket.Models
{
    public partial class ReviewImage
    {
        public int ReviewImages { get; set; }
        public string? ImageUrl { get; set; }
        public int? ProductReviewsId { get; set; }

        public virtual ProductReview? ProductReviews { get; set; }
    }
}
