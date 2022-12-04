namespace Booking.System.Application.ShiftRequests.DTO
{
    public class ShortShiftRequestDto
    {
        public int RequestId { get; set; }
        public string CampName { get; set; }
        public string Shift { get; set; }
        public string ShiftType { get; set; }
        public string Price { get; set; }
    }
}
