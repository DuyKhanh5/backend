using System;
using System.Collections.Generic;

namespace APIEproject.Models
{
    public partial class Office
    {
        public Office()
        {
            Orders = new HashSet<Order>();
            staff = new HashSet<Staff>();
        }

        public int OfficeId { get; set; }
        public string? NameOffice { get; set; }
        public DateTime? DateCreate { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Staff> staff { get; set; }
    }
}
