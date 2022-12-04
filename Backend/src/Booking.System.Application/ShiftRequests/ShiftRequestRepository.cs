using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;


using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Booking.System.Application.ShiftsRequests.DTO;
using Booking.System.Domain.Booking;
using Booking.System.Application.ShiftRequests.DTO;

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

        public async Task<AllShiftRequestsDto> GetAllShiftRequests()
        {
            var listResult = new List<ShortShiftDto>();

            var shiftsByShiftTypeList = await _campDbContext.ShiftByShiftTypes
                .Include(x => x.Shift)
                .Include(x => x.ShiftType)
                .ToListAsync();

            foreach(var shiftEntity in shiftsByShiftTypeList)
            {
                var camp = await _campDbContext.Camps.FirstOrDefaultAsync(x => x.CampId == shiftEntity.Shift.CampId);
                var shiftRequests = await _campDbContext.ShiftRequests
                    .Where(x => x.ShiftByShiftTypeId == shiftEntity.ShiftByShiftTypeId)
                    .ToListAsync();

                listResult.Add(new ShortShiftDto
                {
                    ShiftId = shiftEntity.ShiftId,
                    CampName = camp.Name,
                    Price = shiftEntity.Price.ToString(),
                    ShiftName = shiftEntity.Shift.Name,
                    ShiftType = shiftEntity.ShiftType.Name,
                    BusyPlacesCount = shiftRequests.Count(),
                    PlacesCount = camp.Capacity
                });;
            }

            var result = new AllShiftRequestsDto
            {
                ShortShiftRequests = listResult,
            };

            return result;
        }

        public async Task<AllShiftRequestsDto> GetShiftsTodayDate()
        {
            var listResult = new List<ShortShiftDto>();
            var dateToday = DateOnly.FromDateTime(DateTime.Now);

            var shiftsByShiftTypeList = await _campDbContext.ShiftByShiftTypes
                .Include(x => x.Shift)
                .Include(x => x.ShiftType)
                .ToListAsync();

            foreach (var shiftEntity in shiftsByShiftTypeList)
            {
                var camp = await _campDbContext.Camps.FirstOrDefaultAsync(x => x.CampId == shiftEntity.Shift.CampId);
                var shiftRequests = await _campDbContext.ShiftRequests
                    .Where(x => x.ShiftByShiftTypeId == shiftEntity.ShiftByShiftTypeId)
                    .ToListAsync();

                if (shiftEntity.Shift.DateStart >= dateToday || shiftEntity.Shift.DateEnd <= dateToday)
                    continue;

                listResult.Add(new ShortShiftDto
                {
                    ShiftId = shiftEntity.ShiftId,
                    CampName = camp.Name,
                    Price = shiftEntity.Price.ToString(),
                    ShiftName = shiftEntity.Shift.Name,
                    ShiftType = shiftEntity.ShiftType.Name,
                    BusyPlacesCount = shiftRequests.Count(),
                    PlacesCount = camp.Capacity
                }); ;
            }

            var result = new AllShiftRequestsDto
            {
                ShortShiftRequests = listResult,
            };

            return result;
        }

        //public class GetShiftByDateDto { public string Date { get; set; } }
    }
}
