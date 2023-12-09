using System;
using System.Collections.Generic;

namespace EuphoriaShop.Models
{
    public partial class Product
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string ProductName { get; set; } = null!;
        public string? ProductImgPreview { get; set; }
        public string? ShortDescription { get; set; }
        public string? Description { get; set; }
        public int? Quantity { get; set; }
        public double? PricePreview { get; set; }
        public double? Weight { get; set; }
        public string? Dimensions { get; set; }
        public string? Materials { get; set; }
    }
}
