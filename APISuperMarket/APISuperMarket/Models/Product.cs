using System;
using System.Collections.Generic;

namespace APISuperMarket.Models
{
    public partial class Product
    {
        public Product()
        {
            OrderDetails = new HashSet<OrderDetail>();
            ProductChanges = new HashSet<ProductChange>();
            ProductImages = new HashSet<ProductImage>();
            ProductReviews = new HashSet<ProductReview>();
        }

        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public double? Price { get; set; }
        public int? BrandId { get; set; }
        public string? Description { get; set; }
        public DateTime? Expiry { get; set; }
        public decimal? InventoryQuantity { get; set; }

        public virtual Brand? Brand { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<ProductChange> ProductChanges { get; set; }
        public virtual ICollection<ProductImage> ProductImages { get; set; }
        public virtual ICollection<ProductReview> ProductReviews { get; set; }
    }
}
