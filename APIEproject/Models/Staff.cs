using System;
using System.Collections.Generic;

namespace APIEproject.Models
{
    public partial class Staff
    {
        public int StaffId { get; set; }
        public int? OfficeId { get; set; }
        public string StaffName { get; set; } = null!;
        public string? Email { get; set; }
        public string? Designation { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }

        public virtual Office? Office { get; set; }
    }
}
