using System;
using System.Collections.Generic;

namespace Booking.System.Domain.Booking
{
    public partial class Child
    {
        public Child()
        {
            ShiftRequests = new HashSet<ShiftRequest>();
            Parents = new HashSet<Parent>();
        }

        public int ChildId { get; set; }
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string? Patronymic { get; set; }
        public DateOnly Birthday { get; set; }
        public int AddressId { get; set; }
        public string Snils { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public int? PassportForeignId { get; set; }
        public int? PassportRuId { get; set; }
        public int? BirthCertificateRuId { get; set; }
        public int? BirthCertificateForeignId { get; set; }
        public string? Citizenship { get; set; }

        public virtual Address Address { get; set; } = null!;
        public virtual BirthCertificateForeign? BirthCertificateForeign { get; set; }
        public virtual BirthCertificateRu? BirthCertificateRu { get; set; }
        public virtual PassportForeign? PassportForeign { get; set; }
        public virtual PassportRu? PassportRu { get; set; }
        public virtual ICollection<ShiftRequest> ShiftRequests { get; set; }

        public virtual ICollection<Parent> Parents { get; set; }
    }
}
