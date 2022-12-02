using Microsoft.AspNetCore.Identity;

namespace Booking.System.Domain.Identity
{
    public class AppUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? ThirdName { get; set; }
    }
}