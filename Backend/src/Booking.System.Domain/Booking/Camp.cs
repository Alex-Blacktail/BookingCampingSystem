using System;
using System.Collections.Generic;

namespace Booking.System.Domain.Booking
{
    public partial class Camp
    {
        public Camp()
        {
            Features = new HashSet<Feature>();
            Shifts = new HashSet<Shift>();
            IdLocalAdmins = new HashSet<LocalAdministrator>();
        }

        public int CampId { get; set; }
        public string? ShortName { get; set; }
        public string Name { get; set; } = null!;
        public string? LegalEntity { get; set; }
        public int AddressId { get; set; }
        public int WorkingModeId { get; set; }
        public int Capacity { get; set; }
        public string? WebsiteLink { get; set; }
        public bool? MedicalLicense { get; set; }
        public bool? EducationalLicense { get; set; }
        public string? About { get; set; }
        public int NumberOfBuildings { get; set; }
        public double TheAreaOfTheLand { get; set; }
        public string Food { get; set; } = null!;
        public double ChildsAgeStart { get; set; }
        public double ChildsAgeEnd { get; set; }
        public bool ChildrensHolidayCertificate { get; set; }
        public string? ImagePath { get; set; }

        public virtual Address Address { get; set; } = null!;
        public virtual WorkingMode WorkingMode { get; set; } = null!;
        public virtual ICollection<Feature> Features { get; set; }
        public virtual ICollection<Shift> Shifts { get; set; }

        public virtual ICollection<LocalAdministrator> IdLocalAdmins { get; set; }
    }
}
