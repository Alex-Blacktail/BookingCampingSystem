using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using AutoMapper;
using Microsoft.Extensions.Options;
using Booking.System.Domain;
using Booking.System.Domain.Booking;
using Booking.System.Application.Camps;
using Booking.System.Application.Identity.DTO;
using Booking.System.Application.Camps.DTO;
using Microsoft.EntityFrameworkCore;
using Booking.System.Domain.Identity;
using Booking.System.Application.CampFeature.DTO;
using Booking.System.Application.WorkingMods.DTO;
using Booking.System.Application.Shifts.DTO;
using System.Linq;
using Booking.System.Application.ShiftsTypes.DTO;
using Booking.System.Application.Childs.DTO;
using System.Data;

namespace Booking.System.Application.Childs
{
    public class ChildRepository : IChildRepository
    {
        private readonly IMapper _mapper;

        private readonly CampDbContext _campDbContext;

        public ChildRepository(IMapper mapper, CampDbContext campDbContext)
        {
            _mapper = mapper;
            _campDbContext = campDbContext;
        }

        public async Task<bool> RemoveChildInfo(RemoveChildInfoDto removeChildInfoDto)
        {
            try
            {

                var parent = _campDbContext.Parents.First(p=>p.ParentId== removeChildInfoDto.ParentId);
                var child = _campDbContext.Children.First(c => c.Snils == removeChildInfoDto.SNILS);
                //parent.Children.Remove(child);

                var shiftRequest = _campDbContext.ShiftRequests.Where(c => c.ChildId == child.ChildId).ToList();




                var children = _campDbContext.Children.Include(p => p.Parents).ToList();
                parent.Children.Remove(child);
                child.Parents.Remove(parent);
                _campDbContext.Children.Remove(children.First(x=>x.Snils==child.Snils));
                _campDbContext.SaveChanges();
            }
            catch (Exception ex)
            { throw ex; }

            return true;
        }
        public async Task<bool> CreateChild(ChildDto childDto)
        {
            try
            {
                Address adr = new Address
                {
                    AddressContent = childDto.Address
                };
                _campDbContext.Addresses.Add(adr);
                _campDbContext.SaveChanges();

                string[] birthdayDate = childDto.Birthday.Split("-");
                var child = new Child();

                child.Name = childDto.Name;
                child.Surname = childDto.Surname;
                child.Patronymic = childDto.Patronomyc;
                child.Birthday = new DateOnly(int.Parse(birthdayDate[0]), int.Parse(birthdayDate[1]), int.Parse(birthdayDate[2]));
                child.Snils = childDto.SNILS;
                child.PhoneNumber = childDto.PhoneNumber;
                child.AddressId = adr.AddressId;
                child.Citizenship = childDto.Country;

                child.PassportForeignId = null;
                child.PassportRuId = null;
                child.BirthCertificateForeignId = null;
                child.BirthCertificateRu = null;

                if (childDto.DocumentType == "passportru")
                {
                    //BirthCertificateRu
                    string[] passportDateOfIssue = childDto.PassportDateOfIssue.ToString().Split("-");
                    var PassportRu = new PassportRu
                    {
                        Number = childDto.PassportNumber,
                        Series = childDto.PassportSerial,
                        IssuedBy = childDto.PassportIssuedBy,
                        DateOfIssue = new DateOnly(int.Parse(passportDateOfIssue[0]), int.Parse(passportDateOfIssue[1]), int.Parse(passportDateOfIssue[2]))
                    };
                    _campDbContext.PassportRus.Add(PassportRu);
                    _campDbContext.SaveChanges();

                    child.PassportRuId = PassportRu.PassportId;
                }
                else if (childDto.DocumentType == "passportforeign")
                {
                    string[] passportDateOfIssue = childDto.PassportDateOfIssue.ToString().Split("-");
                    var PassportForeign = new PassportForeign
                    {
                        Number = childDto.PassportNumber,
                        Series = childDto.PassportSerial,
                        IssuedBy = childDto.PassportIssuedBy,
                        DateOfIssue = new DateOnly(int.Parse(passportDateOfIssue[0]), int.Parse(passportDateOfIssue[1]), int.Parse(passportDateOfIssue[2]))
                    };
                    if (childDto.PassportValidity != null)
                    {

                        string[] validity = childDto.PassportValidity.ToString().Split("-");
                        PassportForeign.Validity = new DateOnly(int.Parse(validity[0]), int.Parse(validity[1]), int.Parse(validity[2]));
                    }
                    _campDbContext.PassportForeigns.Add(PassportForeign);
                    _campDbContext.SaveChanges();
                    child.PassportForeignId = PassportForeign.PassportId;
                }
                else if (childDto.DocumentType == "birthru")
                {
                    string[] BirthCertificateDateOfIssue = childDto.BirthDateOfIssue.ToString().Split("-");
                    var BirthCertificateRu = new BirthCertificateRu
                    {
                        Number = childDto.BirthNumber,
                        Series = childDto.BirthSerial,
                        IssuedBy = childDto.BirthIssuedBy,
                        DateOfIssue = new DateOnly(int.Parse(BirthCertificateDateOfIssue[0]), int.Parse(BirthCertificateDateOfIssue[1]), int.Parse(BirthCertificateDateOfIssue[2]))
                    };
                    _campDbContext.BirthCertificateRus.Add(BirthCertificateRu);
                    _campDbContext.SaveChanges();
                    child.BirthCertificateRuId = BirthCertificateRu.BirthCertificateId;
                }
                else if (childDto.DocumentType == "birthforeign")
                {
                    string[] BirthCertificateDateOfIssue = childDto.BirthDateOfIssue.ToString().Split("-");
                    var BirthCertificateForeign = new BirthCertificateForeign
                    {
                        Number = childDto.BirthNumber,
                        Series = childDto.BirthSerial,
                        IssuedBy = childDto.BirthIssuedBy,
                        DateOfIssue = new DateOnly(int.Parse(BirthCertificateDateOfIssue[0]), int.Parse(BirthCertificateDateOfIssue[1]), int.Parse(BirthCertificateDateOfIssue[2]))
                    };
                    _campDbContext.BirthCertificateForeigns.Add(BirthCertificateForeign);
                    _campDbContext.SaveChanges();
                    child.BirthCertificateForeignId = BirthCertificateForeign.BirthCertificateId;
                }
                else { throw new NotImplementedException(); }

                var parent = _campDbContext.Parents.First(p=>p.ParentId == childDto.ParentId);

                _campDbContext.Children.Add(child);
                _campDbContext.SaveChanges();
                parent.Children.Add(child);
                _campDbContext.SaveChanges();

            }
            catch (Exception ex) { throw ex; }
            return true;
        }
    }
}
