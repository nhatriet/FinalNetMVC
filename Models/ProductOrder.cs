using System;
using System.Collections.Generic;

namespace EuphoriaShop.Models
{
    public partial class ProductOrder
    {
        public int ProductorderId { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int? Quantity { get; set; }
        public double Price { get; set; }
    }
}
