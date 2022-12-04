using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

using Booking.System.Domain;
using Booking.System.Domain.Booking;
using Booking.System.Domain.Identity;

using Booking.System.Application.Parents.DTO;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Booking.System.Application.Childs.DTO;
using System;

namespace Booking.System.Application.Parents
{
    public class ParentRepository : IParentRepository
    {
        private readonly IMapper _mapper;

        private readonly CampDbContext _campDbContext;

        public ParentRepository(IMapper mapper, CampDbContext campDbContext)
        {
            _mapper = mapper;
            _campDbContext = campDbContext;
        }

        public async Task<ParentDto> GetParentAndChildInfo(string parentId)
        {
            ParentDto parentDto = new ParentDto();

            var parent = await _campDbContext.Parents.FirstAsync(p => p.ParentId == parentId);

            var parentAddress = await _campDbContext.Addresses.FirstAsync(a => a.AddressId == parent.AddressId);

            var parentStatus = await _campDbContext.Statuses.FirstAsync(s => s.StatusId == parent.StatusId);



            if (parent.PassportRuId != null)
            {
                var ruPass = await _campDbContext.PassportRus.FirstAsync(s => s.PassportId == parent.PassportRuId);
                parentDto.PassportNumber = ruPass.Number;
                parentDto.PassportSerial = ruPass.Series;
                parentDto.PassportDateOfIssue = ruPass.DateOfIssue.Year + "-" + ruPass.DateOfIssue.Month + "-" + ruPass.DateOfIssue.Day;
                parentDto.PassportIssuedBy = ruPass.IssuedBy;
                parentDto.PassportValidity = null;
                parentDto.PassportType = "Паспорт гражданина РФ"; 
            }
            else if (parent.PassportForeignId != null)
            {
                var foreignPass = await _campDbContext.PassportForeigns.FirstAsync(s => s.PassportId == parent.PassportForeignId);
                parentDto.PassportNumber = foreignPass.Number;
                parentDto.PassportSerial = foreignPass.Series;
                parentDto.PassportDateOfIssue = foreignPass.DateOfIssue.Year + "-" + foreignPass.DateOfIssue.Month + "-" + foreignPass.DateOfIssue.Day;
                parentDto.PassportIssuedBy = foreignPass.IssuedBy;
                DateOnly date = (DateOnly)foreignPass.Validity;
                parentDto.PassportValidity = date.Year + "-" + date.Month + "-" + date.Day;
                parentDto.PassportType = "Паспорт гражданина другой страны";
            }
           // else throw new NotImplementedException();

            parentDto.FirstName = parent.Name;
            parentDto.LastName = parent.Surname;
            parentDto.ThirdName = parent.Patronymic;

            parentDto.Address = parentAddress.AddressContent;
            parentDto.Country = parent.Citizenship;
            parentDto.SNILS = parent.Snils;

            // string[] parentBirthday = parent.Birthday.ToString().Split("-");
            // parentDto.Birthday = new DateOnly(int.Parse(validity[0]), int.Parse(validity[1]), int.Parse(validity[2]));

            parentDto.Birthday = parent.Birthday.Year + "-" + parent.Birthday.Month + "-" + parent.Birthday.Day;

            parentDto.Email = _campDbContext.AspNetUsers.First(u => u.Id == parent.ParentId).Email;
            parentDto.PhoneNumber= _campDbContext.AspNetUsers.First(u => u.Id == parent.ParentId).PhoneNumber;
            parentDto.UserName = _campDbContext.AspNetUsers.First(u => u.Id == parent.ParentId).UserName;

            parentDto.Status = parentStatus.Name;

            parentDto.Children = new List<ChildForParentDto>();


            var children = _campDbContext.Children.Include(p => p.Parents).ToList();
            //var children = parent.Children.ToList();

            if (children.Count > 0)
            {
                foreach (var child in children)
                {
                    var childAddress = await _campDbContext.Addresses.FirstAsync(a => a.AddressId == child.AddressId);

                    var childDto = new ChildForParentDto();
                    childDto.Name = child.Name;
                    childDto.Surname = child.Surname;
                    childDto.Patronomyc = child.Patronymic;
                    childDto.Country = child.Citizenship;
                    childDto.SNILS = child.Snils;
                    childDto.Address = childAddress.AddressContent;
                    childDto.PhoneNumber = child.PhoneNumber;

                    childDto.Birthday = child.Birthday.Year + "-" + child.Birthday.Month + "-" + child.Birthday.Day;

                    if (child.PassportRuId != null)
                    {
                        var ruPass = await _campDbContext.PassportRus.FirstAsync(s => s.PassportId == child.PassportRuId);
                        childDto.PassportNumber = ruPass.Number;
                        childDto.PassportSerial = ruPass.Series;
                        childDto.PassportDateOfIssue = ruPass.DateOfIssue.Year + "-" + ruPass.DateOfIssue.Month + "-" + ruPass.DateOfIssue.Day;
                        childDto.PassportIssuedBy = ruPass.IssuedBy;
                        childDto.PassportValidity = null;

                        childDto.BirthNumber = null;
                        childDto.BirthSerial = null;
                        childDto.BirthDateOfIssue = null;
                        childDto.BirthIssuedBy = null;

                        childDto.DocumentType = "Паспорт гражданина РФ";
                    }
                    else if (child.PassportForeignId != null)
                    {
                        var foreignPass = await _campDbContext.PassportForeigns.FirstAsync(s => s.PassportId == child.PassportForeignId);
                        childDto.PassportNumber = foreignPass.Number;
                        childDto.PassportSerial = foreignPass.Series;
                        childDto.PassportDateOfIssue = foreignPass.DateOfIssue.Year + "-" + foreignPass.DateOfIssue.Month + "-" + foreignPass.DateOfIssue.Day;
                        childDto.PassportIssuedBy = foreignPass.IssuedBy;
                        DateOnly date = (DateOnly)foreignPass.Validity;
                        childDto.PassportValidity = date.Year + "-" + date.Month + "-" + date.Day;

                        childDto.BirthNumber = null;
                        childDto.BirthSerial = null;
                        childDto.BirthDateOfIssue = null;
                        childDto.BirthIssuedBy = null;

                        childDto.DocumentType = "Паспорт гражданина другой страны";
                    }
                    else if (child.BirthCertificateRuId != null)
                    {
                        var birthCertificateRu = await _campDbContext.BirthCertificateRus.FirstAsync(s => s.BirthCertificateId == child.BirthCertificateRuId);
                        childDto.BirthNumber = birthCertificateRu.Number;
                        childDto.BirthSerial = birthCertificateRu.Series;
                        childDto.BirthDateOfIssue = birthCertificateRu.DateOfIssue.Year + "-" + birthCertificateRu.DateOfIssue.Month + "-" + birthCertificateRu.DateOfIssue.Day;
                        childDto.BirthIssuedBy = birthCertificateRu.IssuedBy;

                        childDto.PassportNumber = null;
                        childDto.PassportSerial = null;
                        childDto.PassportDateOfIssue = null;
                        childDto.PassportIssuedBy = null;
                        childDto.PassportValidity = null;

                        childDto.DocumentType = "Свидетельство о рождении гражданина РФ";
                    }
                    else if (child.BirthCertificateForeignId != null)
                    {
                        var birthCertificateForeign = await _campDbContext.BirthCertificateForeigns.FirstAsync(s => s.BirthCertificateId == child.BirthCertificateForeignId);
                        childDto.BirthNumber = birthCertificateForeign.Number;
                        childDto.BirthSerial = birthCertificateForeign.Series;
                        childDto.BirthDateOfIssue = birthCertificateForeign.DateOfIssue.Year + "-" + birthCertificateForeign.DateOfIssue.Month + "-" + birthCertificateForeign.DateOfIssue.Day;
                        childDto.BirthIssuedBy = birthCertificateForeign.IssuedBy;

                        childDto.PassportNumber = null;
                        childDto.PassportSerial = null;
                        childDto.PassportDateOfIssue = null;
                        childDto.PassportIssuedBy = null;
                        childDto.PassportValidity = null;

                        childDto.DocumentType = "Свидетельство о рождении гражданина другой страны";
                    }

                    parentDto.Children.Add(childDto);
                }
            }
            return parentDto;
        }
    }
}