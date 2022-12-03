using System;
using System.Collections.Generic;

namespace Booking.System.Domain
{
    public partial class ShiftByShiftType
    {
        public ShiftByShiftType()
        {
            ShiftRequests = new HashSet<ShiftRequest>();
        }

        public int ShiftByShiftTypeId { get; set; }
        public int ShiftTypeId { get; set; }
        public int ShiftId { get; set; }
        public decimal Price { get; set; }

        public virtual Shift Shift { get; set; } = null!;
        public virtual ShiftType ShiftType { get; set; } = null!;
        public virtual ICollection<ShiftRequest> ShiftRequests { get; set; }
    }
}
