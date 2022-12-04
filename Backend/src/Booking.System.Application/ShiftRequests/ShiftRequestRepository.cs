using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;


using AutoMapper;
using Microsoft.Extensions.Options;
using Booking.System.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Booking.System.Application.ShiftsRequests.DTO;
using Booking.System.Domain.Booking;

namespace Booking.System.Application.ShiftsRequests
{
    public class ShiftRequestRepository : IShiftRequestRepository
    {
        private readonly IMapper _mapper;

        private readonly CampDbContext _campDbContext;

        public ShiftRequestRepository(IMapper mapper, CampDbContext campDbContext)
        {
            _mapper = mapper;
            _campDbContext = campDbContext;
        }
        public async Task<GetShiftRequestDto> GetRequestInfo()
        {

            return new GetShiftRequestDto { };
        }
        public async Task<GetShiftRequestDto> CreateRequest(CreateRequestDto createRequestDto)
        {

            var parent = _campDbContext.Parents.First(p => p.ParentId == createRequestDto.ParentId);
            var child = _campDbContext.Children.First(p => p.Snils == createRequestDto.ChildSNILS);
            var shiftByShift = _campDbContext.ShiftByShiftTypes.First(f => f.ShiftByShiftTypeId == createRequestDto.ShiftByShiftTypeId);
            var shift = _campDbContext.Shifts.First(s => s.ShiftId == shiftByShift.ShiftId);
            var camp = _campDbContext.Camps.First(x => x.CampId == shift.CampId);
            var campAddress = _campDbContext.Addresses.First(ca => ca.AddressId == camp.AddressId);

            ShiftRequest shiftRequest = new ShiftRequest();
            shiftRequest.ParentId = parent.ParentId;
            shiftRequest.ShiftByShiftTypeId = createRequestDto.ShiftByShiftTypeId;
            shiftRequest.ChildId = child.ChildId;
            shiftRequest.Price = shiftByShift.Price;

            _campDbContext.ShiftRequests.Add(shiftRequest);
            _campDbContext.SaveChanges();

            GetShiftRequestDto shiftRequestDto = new GetShiftRequestDto();
            shiftRequestDto.CampName = camp.Name;
            shiftRequestDto.CampAddress = campAddress.AddressContent;
            shiftRequestDto.Shift = shift.Name;
            shiftRequestDto.ChildPhone = child.PhoneNumber;
            shiftRequestDto.ParentPhone = parent.PhoneNumber;
            shiftRequestDto.ParentName = parent.Name;
            shiftRequestDto.ParentSurnaname = parent.Surname;
            shiftRequestDto.ParentPatronomyc = parent.Patronymic;
            shiftRequestDto.ChildName = child.Name;
            shiftRequestDto.ChildSurnaname = child.Surname;
            shiftRequestDto.ChildPatronomyc = child.Patronymic;
            shiftRequestDto.ShiftType = _campDbContext.ShiftTypes.First(x => x.ShiftTypeId == shiftByShift.ShiftTypeId).Name;
            shiftRequestDto.Price = shiftByShift.Price.ToString();
            shiftRequestDto.RequestId = shiftRequest.RequestId;

            return shiftRequestDto;
        }
    }
}
