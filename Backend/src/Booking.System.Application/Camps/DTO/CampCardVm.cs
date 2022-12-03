using Booking.System.Application.WorkingMods.DTO;
using System.ComponentModel.DataAnnotations;
using Booking.System.Application.Shifts.DTO;
using Booking.System.Application.CampFeature.DTO;

namespace Booking.System.Application.Camps.DTO
{
    public class CampCardVm
    {
       public List<CapmCardDto> capmCardDtos { get; set; }

    }
}