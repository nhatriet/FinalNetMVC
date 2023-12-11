using System;
using System.Collections.Generic;

namespace EuphoriaShop.Models
{
    public partial class Statistic
    {
        public int StatId { get; set; }
        public int? Year { get; set; }
        public int? TotalProduct { get; set; }
    }
}
