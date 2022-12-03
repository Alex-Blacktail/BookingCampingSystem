using System;
using System.Collections.Generic;

namespace Booking.System.Domain.Booking
{
    public partial class ShiftRequest
    {
        public int RequestId { get; set; }
        public int ChildId { get; set; }
        public decimal Price { get; set; }
        public int ShiftByShiftTypeId { get; set; }
        public string ParentId { get; set; } = null!;

        public virtual Child Child { get; set; } = null!;
        public virtual Parent Parent { get; set; } = null!;
        public virtual ShiftByShiftType ShiftByShiftType { get; set; } = null!;
    }
}
