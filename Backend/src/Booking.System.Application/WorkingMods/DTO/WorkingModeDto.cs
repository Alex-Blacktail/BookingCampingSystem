using System.ComponentModel.DataAnnotations;

namespace Booking.System.Application.WorkingMods.DTO
{
    public class WorkingModeDto
    {
        public string SundayStart { get; set; }
        public string SundayEnd { get; set; }
        public string MondayStart { get; set; }
        public string MondayEnd { get; set; }
        public string TuesdayStart { get; set; }
        public string TuesdayEnd { get; set; }
        public string WednesdayStart { get; set; }
        public string WednesdayEnd { get; set; }
        public string ThursdayStart { get; set; }
        public string ThursdayEnd { get; set; }
        public string FridayStart { get; set; }
        public string FridayEnd { get; set; }
        public string SaturdayStart { get; set; }
        public string SaturdayEnd { get; set; }
    }
}