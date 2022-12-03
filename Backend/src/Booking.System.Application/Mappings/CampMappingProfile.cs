using AutoMapper;
using Booking.System.Domain.Identity;
using Booking.System.Application.Identity.DTO;
using AutoMapper.Features;
using Booking.System.Application.CampFeature.DTO;
using Booking.System.Application.WorkingMods.DTO;
using Booking.System.Domain;
using Booking.System.Application.ShiftsTypes.DTO;

namespace Booking.System.Application.Mappings
{
    public class CampMappingProfile : Profile
    {
        public CampMappingProfile()
        {
            CreateMap<Feature, FeatureDto>();
            CreateMap<WorkingMode, WorkingModeDto>();
            CreateMap<ShiftType, ShiftTypeDto>();
        }
    }
}
