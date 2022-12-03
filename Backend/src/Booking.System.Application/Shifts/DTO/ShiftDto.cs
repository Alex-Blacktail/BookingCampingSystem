using System.ComponentModel.DataAnnotations;
using Booking.System.Application.ShiftsTypes.DTO;

namespace Booking.System.Application.Shifts.DTO
{
    public class ShiftDto
    {
        //DateOnly --> string
        public string DateStart { get; set; }
        //DateOnly --> string
        public string DateEnd { get; set; }
        public string? Name { get; set; }
        public List<ShiftTypeDto> ShiftTypeDtos { get; set; }
    }
}