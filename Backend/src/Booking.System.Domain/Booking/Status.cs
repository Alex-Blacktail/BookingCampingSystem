using System;
using System.Collections.Generic;

namespace Booking.System.Domain.Booking
{
    public partial class Status
    {
        public Status()
        {
            Parents = new HashSet<Parent>();
        }

        public int StatusId { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Parent> Parents { get; set; }
    }
}
