using System;
using System.Collections.Generic;
using Booking.System.Domain.IdentityAspNet;

namespace Booking.System.Domain
{
    public partial class LocalAdministrator
    {
        public LocalAdministrator()
        {
            IdCamps = new HashSet<Camp>();
        }

        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string? Patronomyc { get; set; }
        public string LocalAdministratorId { get; set; } = null!;

        public virtual AspNetUser LocalAdministratorNavigation { get; set; } = null!;

        public virtual ICollection<Camp> IdCamps { get; set; }
    }
}
