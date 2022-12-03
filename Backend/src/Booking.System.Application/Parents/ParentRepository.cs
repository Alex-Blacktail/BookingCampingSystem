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

        public async Task<ParentDto> GetCampCards(string parentId)
        {
            ParentDto parentDto = new ParentDto();

            var parent = await _campDbContext.Parents.FirstAsync(p => p.ParentId == parentId);

            var parentAddress = await _campDbContext.Addresses.FirstAsync(a=>a.AddressId==parent.AddressId);

            var parentStatus = await _campDbContext.Statuses.FirstAsync(s=>s.StatusId==parent.StatusId);

            if (parent.PassportRuId != null)
            {
                var ruPass = await _campDbContext.PassportRus.FirstAsync(s => s.PassportId == parent.PassportRuId);
                parentDto.PassportNumber = ruPass.Number;
                parentDto.PassportSerial = ruPass.Series;
                parentDto.PassportDateOfIssue = ruPass.DateOfIssue.Year + "-" + ruPass.DateOfIssue.Month + "-" + ruPass.DateOfIssue.Day;
                parentDto.PassportIssuedBy= ruPass.IssuedBy;
                parentDto.PassportValidity = null;
            }
            if (parent.PassportForeignId != null)
            {
                var foreignPass = await _campDbContext.PassportForeigns.FirstAsync(s => s.PassportId == parent.PassportForeignId);
                parentDto.PassportNumber = foreignPass.Number;
                parentDto.PassportSerial = foreignPass.Series;
                parentDto.PassportDateOfIssue = foreignPass.DateOfIssue.Year + "-" + foreignPass.DateOfIssue.Month + "-" + foreignPass.DateOfIssue.Day;
                parentDto.PassportIssuedBy = foreignPass.IssuedBy;
                DateOnly date = (DateOnly)foreignPass.Validity;
                parentDto.PassportValidity = date.Year + "-" + date.Month + "-" + date.Day; ;
            }

            parentDto.FirstName = parent.Name;
            parentDto.ThirdName = parent.Patronymic;


            return parentDto;
        }
    }
}