using System.ComponentModel.DataAnnotations;

namespace Booking.System.Application.Identity.DTO
{
    public class UserRegistrationDto
    {
        [Required(ErrorMessage = "UserName is required")]
        public string? UserName { get; init; }

        public string? FirstName { get; init; }
        public string? LastName { get; init; }
        public string? ThirdName { get; init; }

        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; init; }

        public string? Email { get; init; }
        public string? PhoneNumber { get; init; }
    }
}
