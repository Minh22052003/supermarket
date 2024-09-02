﻿using System;
using System.Collections.Generic;

namespace APISuperMarket.Models
{
    public partial class CartProduct
    {
        public int? ProductId { get; set; }
        public int? CartId { get; set; }

        public virtual Cart? Cart { get; set; }
        public virtual Product? Product { get; set; }
    }
}