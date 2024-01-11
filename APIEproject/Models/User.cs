using System;
using System.Collections.Generic;

namespace APIEproject.Models
{
    public partial class User
    {
        public User()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? ConfirmPassword { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
