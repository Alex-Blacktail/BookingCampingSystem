using System.ComponentModel.DataAnnotations;

namespace Booking.System.Application.Parents.DTO
{
    public class ParentDto
    {
        public List<ChildForParentDto> Children { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? ThirdName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
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
