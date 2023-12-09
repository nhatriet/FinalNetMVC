using System;
using System.Collections.Generic;

namespace EuphoriaShop.Models
{
    public partial class ProductSize
    {
        public int ProductsizeId { get; set; }
        public int ProductId { get; set; }
        public int SizeId { get; set; }
        public int? Quantity { get; set; }
        public double Price { get; set; }

    }
}
