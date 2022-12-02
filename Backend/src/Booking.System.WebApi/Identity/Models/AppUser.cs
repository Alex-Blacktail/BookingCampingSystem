using Microsoft.AspNetCore.Identity;

namespace Booking.System.WebApi.Identity.Models
{
    public class AppUser : IdentityUser
    {
        public string DisplayName { get; set; }
    }
}