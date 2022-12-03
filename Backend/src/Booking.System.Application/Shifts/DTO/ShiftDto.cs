using System.ComponentModel.DataAnnotations;
using Booking.System.Application.ShiftsTypes.DTO;

namespace Booking.System.Application.Shifts.DTO
{
    public class ShiftDto
    {
        public DateOnly DateStart { get; set; }
        public DateOnly DateEnd { get; set; }
        public string? Name { get; set; }
        public List<ShiftTypeDto> ShiftTypeDtos { get; set; }
    }
}