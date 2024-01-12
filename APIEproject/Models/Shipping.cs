using System;
using System.Collections.Generic;

namespace APIEproject.Models
{
    public partial class Shipping
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int? Price { get; set; }
        public int? OrderId { get; set; }

        public virtual Order? Order { get; set; }
    }
}
