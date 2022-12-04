using System;
using System.Collections.Generic;

namespace Booking.System.Domain.Booking
{
    public partial class Shift
    {
        public Shift()
        {
            ShiftByShiftTypes = new HashSet<ShiftByShiftType>();
        }

        public int ShiftId { get; set; }
        public DateOnly DateStart { get; set; }
        public DateOnly DateEnd { get; set; }
        public string? Name { get; set; }
        public int CampId { get; set; }

        public virtual Camp Camp { get; set; } = null!;
        public virtual ICollection<ShiftByShiftType> ShiftByShiftTypes { get; set; }
    }
}
