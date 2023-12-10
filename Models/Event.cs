using System;
using System.Collections.Generic;

namespace EuphoriaShop.Models
{
    public partial class Event
    {
        public int EventId { get; set; }
        public string? EventName { get; set; }
        public string? EventTopic { get; set; }
        public string? EventImg { get; set; }
        public string? ListProductId { get; set; }
    }
}
