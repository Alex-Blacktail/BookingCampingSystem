using System;
using System.Collections.Generic;

namespace Booking.System.Domain
{
    public partial class Feature
    {
        public int FeatureId { get; set; }
        public string Name { get; set; } = null!;
        public int CampId { get; set; }

        public virtual Camp Camp { get; set; } = null!;
    }
}
