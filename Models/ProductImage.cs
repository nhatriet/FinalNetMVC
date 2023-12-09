using System;
using System.Collections.Generic;

namespace EuphoriaShop.Models
{
    public partial class ProductImage
    {
        public int ProductimgId { get; set; }
        public int ProductId { get; set; }
        public string? ProductimgUrl { get; set; }
    }
}
