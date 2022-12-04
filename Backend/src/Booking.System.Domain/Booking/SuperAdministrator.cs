using System;
using System.Collections.Generic;
using Booking.System.Domain.IdentityAspNet;

namespace Booking.System.Domain.Booking
{
    public partial class SuperAdministrator
    {
        public string SuperAdministratorId { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string? Patronomyc { get; set; }

        public virtual AspNetUser SuperAdministratorNavigation { get; set; } = null!;
    }
}
