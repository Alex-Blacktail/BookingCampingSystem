using AutoMapper;
using Booking.System.Domain.Identity;
using Booking.System.Application.Identity.DTO;

namespace Booking.System.Application.Mappings
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile() 
        {
            CreateMap<UserRegistrationDto, AppUser>();
            CreateMap<ParentRegistrationDto, AppUser>();
        }
    }
}
