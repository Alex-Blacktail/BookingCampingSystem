
using System.ComponentModel.DataAnnotations;

namespace Booking.System.Application.LocalAdmins.DTO
{
    public class CampInfoDto
    {
        public int RequestId { get; set; }
        public string ParentName { get; set; }
        public string ChildName { get; set; }
        public string ParentSurnaname { get; set; }
        public string ChildSurnaname { get; set; }
        public string? ParentPatronomyc { get; set; }
        public string? ChildPatronomyc { get; set; }
        public string CampName { get; set; }
        public string CampAddress { get; set; }
        public string ParentPhone { get; set; }
        public string ChildPhone { get; set; }
        public string ShiftInfo { get; set; }
     //   public string ShiftType { get; set; }
        public string Price { get; set; }

    }
}