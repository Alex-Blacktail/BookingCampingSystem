using Booking.System.Domain.Booking;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Booking.System.Application.Identity.DTO
{
    public class ParentRegistrationDto
    {
        public UserRegistrationDto UserRegistration { get; set; }
        public int StatusId { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string SNILS { get; set; }
        public string Birthday { get; set; }
        public string PassportType { get; set; }
        public string PassportSerial { get; set; }
        public string PassportNumber { get; set; }
        public string PassportDateOfIssue { get; set; }
        public string PassportIssuedBy { get; set; }
        public string? PassportValidity { get; set; }
    }
}
