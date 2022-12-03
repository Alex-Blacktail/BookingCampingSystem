using System;
using System.Collections.Generic;

namespace Booking.System.Domain.Booking
{
    public partial class PassportRu
    {
        public PassportRu()
        {
            Children = new HashSet<Child>();
            Parents = new HashSet<Parent>();
        }

        public int PassportId { get; set; }
        public string Series { get; set; } = null!;
        public string Number { get; set; } = null!;
        public DateOnly DateOfIssue { get; set; }
        public string IssuedBy { get; set; } = null!;

        public virtual ICollection<Child> Children { get; set; }
        public virtual ICollection<Parent> Parents { get; set; }
    }
}
