using System;
using System.Collections.Generic;

namespace APISuperMarket.Models
{
    public partial class ProductImage
    {
        public int ProductImagesId { get; set; }
        public int? ProductId { get; set; }
        public string? ImageUrl { get; set; }

        public virtual Product? Product { get; set; }
    }
}
