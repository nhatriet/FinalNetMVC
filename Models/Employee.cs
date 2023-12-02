using System;
using System.Collections.Generic;

namespace EuphoriaShop.Models
{
    public partial class Employee
    {
        public int EmployeeId { get; set; }
        public int AccountId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? Birthday { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }

        public virtual Account Account { get; set; } = null!;
    }
}
