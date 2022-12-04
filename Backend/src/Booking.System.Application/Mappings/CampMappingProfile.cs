using AutoMapper;
using Booking.System.Domain.Booking;
using Booking.System.Application.CampFeature.DTO;
using Booking.System.Application.WorkingMods.DTO;
using Booking.System.Application.ShiftsTypes.DTO;

namespace Booking.System.Application.Mappings
{
    public class CampMappingProfile : Profile
    {
        public CampMappingProfile()
        {
            CreateMap<Feature, FeatureDto>();
            CreateMap<WorkingMode, WorkingModeDto>();
            CreateMap<WorkingModeDto, WorkingMode>();
            CreateMap<ShiftType, ShiftTypeDto>();
        }
    }
}
