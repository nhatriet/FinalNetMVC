using System;
using System.Collections.Generic;

namespace EuphoriaShop.Models
{
    public partial class About
    {
       /* internal int about_id;*/

        public int AboutId { get; set; }
        public string? AboutTitle { get; set; }
        public string? AboutSub { get; set; }
        public string? AboutTopic { get; set; }
        public string? AboutImg { get; set; }
        public string? AboutName { get; set; }
    }
}
