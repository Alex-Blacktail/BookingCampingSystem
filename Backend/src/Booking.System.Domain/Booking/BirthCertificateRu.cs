﻿using System;
using System.Collections.Generic;

namespace Booking.System.Domain.Booking
{
    public partial class BirthCertificateRu
    {
        public BirthCertificateRu()
        {
            Children = new HashSet<Child>();
        }

        public int BirthCertificateId { get; set; }
        public string Series { get; set; } = null!;
        public string Number { get; set; } = null!;
        public DateOnly DateOfIssue { get; set; }
        public string IssuedBy { get; set; } = null!;

        public virtual ICollection<Child> Children { get; set; }
    }
}
