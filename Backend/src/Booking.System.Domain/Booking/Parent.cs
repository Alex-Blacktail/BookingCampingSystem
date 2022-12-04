using System;
using System.Collections.Generic;
using Booking.System.Domain.IdentityAspNet;

namespace Booking.System.Domain.Booking
{
    public partial class Parent
    {
        public Parent()
        {
            ShiftRequests = new HashSet<ShiftRequest>();
            Children = new HashSet<Child>();
        }

        public string ParentId { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string? Patronymic { get; set; }
        public int StatusId { get; set; }
        public DateOnly Birthday { get; set; }
        public int AddressId { get; set; }
        public string Snils { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Email { get; set; } = null!;
        public int? PassportForeignId { get; set; }
        public int? PassportRuId { get; set; }
        public string? Citizenship { get; set; }

        public virtual Address Address { get; set; } = null!;
        public virtual AspNetUser ParentNavigation { get; set; } = null!;
        public virtual PassportForeign? PassportForeign { get; set; }
        public virtual PassportRu? PassportRu { get; set; }
        public virtual Status Status { get; set; } = null!;
        public virtual ICollection<ShiftRequest> ShiftRequests { get; set; }

        public virtual ICollection<Child> Children { get; set; }
    }
}
