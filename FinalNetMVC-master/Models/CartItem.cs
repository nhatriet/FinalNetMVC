using System;
using System.Collections.Generic;

namespace EuphoriaShop.Models
{
    public partial class CartItem
    {
        
        public int ProductId { get; set; }
        public string? Name { get; set; } 
        public string? img { get; set; }
        public double Gia { get; set; }
        public int soluong { get; set; }

       public double GiaTien => soluong * Gia;
        


    }
}
