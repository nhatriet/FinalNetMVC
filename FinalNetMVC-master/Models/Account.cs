using System;
using System.Collections.Generic;

namespace EuphoriaShop.Models
{
    public partial class Account
    {
        public Account()
        {
            Customers = new HashSet<Customer>();
            Employees = new HashSet<Employee>();
        }

        public int AccountId { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int RoleId { get; set; }
        public string? VerificationCode { get; set; }
        public string? ResetPasscode { get; set; }

        public virtual Role Role { get; set; } = null!;
        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
