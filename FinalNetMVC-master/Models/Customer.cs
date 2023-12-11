using System;
using System.Collections.Generic;

namespace EuphoriaShop.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        public int CustomerId { get; set; }
        public int AccountId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? Birthday { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }

        public virtual Account Account { get; set; } = null!;
        public virtual ICollection<Order> Orders { get; set; }
    }
}
