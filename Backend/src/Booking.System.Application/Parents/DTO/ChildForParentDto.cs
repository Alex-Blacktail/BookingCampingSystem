using System.ComponentModel.DataAnnotations;

namespace Booking.System.Application.Parents.DTO
{
    public class ChildForParentDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? Patronomyc { get; set; }
        public string Birthday { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string SNILS { get; set; }
        public string DocumentType { get; set; }
        public string? PassportSerial { get; set; }
        public string? PassportNumber { get; set; }
        public string? PassportDateOfIssue { get; set; }
        public string? PassportIssuedBy { get; set; }
        public string? PassportValidity { get; set; }
        public string? BirthSerial { get; set; }
        public string? BirthNumber { get; set; }
        public string? BirthDateOfIssue { get; set; }
        public string? BirthIssuedBy { get; set; }
        public string PhoneNumber { get; set; }
    }
}
