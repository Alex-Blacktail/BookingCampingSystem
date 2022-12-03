using System.ComponentModel.DataAnnotations;

namespace Booking.System.Application.Parents.DTO
{
    public class ParentDto
    {
        public List<ChildDto> Children { get; set; }
        public string? UserName { get; init; }
        public string? FirstName { get; init; }
        public string? LastName { get; init; }
        public string? ThirdName { get; init; }
        public string? Email { get; init; }
        public string? PhoneNumber { get; init; }
        public string Status { get; set; }
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
