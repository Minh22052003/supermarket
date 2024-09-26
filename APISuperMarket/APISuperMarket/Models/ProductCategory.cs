using System;
using System.Collections.Generic;

namespace APISuperMarket.Models
{
    public partial class ProductCategory
    {
        public int ProductCategoryId { get; set; }
        public int? ProductId { get; set; }
        public int? CategoryId { get; set; }

        public virtual Category? Category { get; set; }
        public virtual Product? Product { get; set; }
    }
}
