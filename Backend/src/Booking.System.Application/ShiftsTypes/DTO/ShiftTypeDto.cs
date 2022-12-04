using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;

namespace Booking.System.Application.ShiftsTypes.DTO
{
    public class ShiftTypeDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int? ShiftByShiftTypeId { get; set; }
    }
}