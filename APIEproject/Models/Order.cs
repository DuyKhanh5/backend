﻿using System;
using System.Collections.Generic;

namespace APIEproject.Models
{
    public partial class Order
    {
        public Order()
        {
            Shippings = new HashSet<Shipping>();
        }

        public int OrderId { get; set; }
        public string? Description { get; set; }
        public int? UserId { get; set; }
        public int? OfficeId { get; set; }

        public virtual Office? Office { get; set; }
        public virtual User? User { get; set; }
        public virtual ICollection<Shipping> Shippings { get; set; }
    }
}
