using Microsoft.AspNetCore.Identity;
using Booking.System.Application.Identity.DTO;

namespace Booking.System.Application.Identity
{
    public interface IUserAuthenticationRepository
    {
        Task<IdentityResult> RegisterUserAsync(UserRegistrationDto userRetistrationDto);
    }
}
