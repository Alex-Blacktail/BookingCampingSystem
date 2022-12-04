namespace Booking.System.Application.ShiftRequests.DTO
{
    public class ShortShiftDto
    {
        public int ShiftId { get; set; }
        public string CampName { get; set; }
        public string ShiftName { get; set; }
        public string ShiftType { get; set; }
        public string Price { get; set; }

        public string DateStart { get; set; }
        public string DateEnd { get; set; }

        public int PlacesCount { get; set; }
        public int BusyPlacesCount { get; set; }
    }
}
