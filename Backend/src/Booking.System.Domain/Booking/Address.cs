using System;
using System.Collections.Generic;

namespace Booking.System.Domain.Booking
{
    public partial class Address
    {
        public Address()
        {
            Camps = new HashSet<Camp>();
            Children = new HashSet<Child>();
            Parents = new HashSet<Parent>();
        }

        public int AddressId { get; set; }
        public string AddressContent { get; set; } = null!;
        public string Citizenship { get; set; } = null!;

        public virtual ICollection<Camp> Camps { get; set; }
        public virtual ICollection<Child> Children { get; set; }
        public virtual ICollection<Parent> Parents { get; set; }
    }
}
