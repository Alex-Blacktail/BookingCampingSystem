using System;
using System.Collections.Generic;

namespace Booking.System.Domain.Booking
{
    public partial class ShiftType
    {
        public ShiftType()
        {
            ShiftByShiftTypes = new HashSet<ShiftByShiftType>();
        }

        public int ShiftTypeId { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<ShiftByShiftType> ShiftByShiftTypes { get; set; }
    }
}
