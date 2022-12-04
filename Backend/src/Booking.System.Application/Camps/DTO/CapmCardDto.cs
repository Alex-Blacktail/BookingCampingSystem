using Booking.System.Application.WorkingMods.DTO;
using System.ComponentModel.DataAnnotations;
using Booking.System.Application.Shifts.DTO;
using Booking.System.Application.CampFeature.DTO;

namespace Booking.System.Application.Camps.DTO
{
    public class CapmCardDto
    {
      //  public string? ShortName { get; set; }
        public string Name { get; set; }
  //      public string? LegalEntity { get; set; }
        public string Address { get; set; }
        //public WorkingModeDto WorkingModeDto { get; set; }
  //      public string WorkingModeDto { get; set; }
        public int Capacity { get; set; }
  //      public string? WebsiteLink { get; set; }
        public bool? MedicalLicense { get; set; }
        public bool? EducationalLicense { get; set; }
   //     public string? About { get; set; }
   //     public int NumberOfBuildings { get; set; }
   //     public double TheAreaOfTheLand { get; set; }
    //    public string Food { get; set; } = null!;
    //    public double ChildsAgeStart { get; set; }
   //     public double ChildsAgeEnd { get; set; }
        public bool ChildrensHolidayCertificate { get; set; }
        public List<ShiftDto> Shifts { get; set; }
   //     public List<FeatureDto> Features { get; set; }

    }
}