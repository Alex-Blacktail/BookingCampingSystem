using System.ComponentModel.DataAnnotations;

namespace Booking.System.Application.ShiftsRequests.DTO
{
    /// <summary>
    /// Создать заявку
    /// </summary>
    public class CreateRequestDto
    {
        public string ParentId { get; set; }
        public string ChildSNILS { get; set; }

        public int ShiftByShiftTypeId { get; set; }

    }
}