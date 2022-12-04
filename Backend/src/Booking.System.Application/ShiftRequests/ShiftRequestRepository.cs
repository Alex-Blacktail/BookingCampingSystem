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
using System.Globalization;

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
                    DateStart = $"{shiftEntity.Shift.DateStart.Year}-{shiftEntity.Shift.DateStart.Month}-{shiftEntity.Shift.DateStart.Day}",
                    DateEnd = $"{shiftEntity.Shift.DateEnd.Year}-{shiftEntity.Shift.DateEnd.Month}-{shiftEntity.Shift.DateEnd.Day}",
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
                    DateStart = $"{shiftEntity.Shift.DateStart.Year}-{shiftEntity.Shift.DateStart.Month}-{shiftEntity.Shift.DateStart.Day}",
                    DateEnd = $"{shiftEntity.Shift.DateEnd.Year}-{shiftEntity.Shift.DateEnd.Month}-{shiftEntity.Shift.DateEnd.Day}",
                    BusyPlacesCount = shiftRequests.Count(),
                    PlacesCount = camp.Capacity
                });
            }

            var result = new AllShiftRequestsDto
            {
                ShortShiftRequests = listResult,
            };

            return result;
        }

        public async Task<VisualDataVm> GetMonthsShifts()
        {
            var listResult = new List<ShortShiftDto>();

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

                listResult.Add(new ShortShiftDto
                {
                    ShiftId = shiftEntity.ShiftId,
                    CampName = camp.Name,
                    Price = shiftEntity.Price.ToString(),
                    ShiftName = shiftEntity.Shift.Name,
                    ShiftType = shiftEntity.ShiftType.Name,
                    DateStart = $"{shiftEntity.Shift.DateStart.Year}-{shiftEntity.Shift.DateStart.Month}-{shiftEntity.Shift.DateStart.Day}",
                    DateEnd = $"{shiftEntity.Shift.DateEnd.Year}-{shiftEntity.Shift.DateEnd.Month}-{shiftEntity.Shift.DateEnd.Day}",
                    BusyPlacesCount = shiftRequests.Count(),
                    PlacesCount = camp.Capacity
                }); 
            }

            var result = new AllShiftRequestsDto
            {
                ShortShiftRequests = listResult,
            };
            VisualDataVm listData = new VisualDataVm();
            string[] months = new string[] {"Январь", "Февраль", "Март", "Апрель", "Май", "Июнь", "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь"};
            decimal[] shiftCount = new decimal[12];
            foreach (var shiftRequest in result.ShortShiftRequests)
            {
                if (DateOnly.Parse(shiftRequest.DateStart).Month == 1)
                    shiftCount[0] += Convert.ToDecimal(shiftRequest.Price);
                else if (DateOnly.Parse(shiftRequest.DateStart).Month == 2)
                    shiftCount[1] += Convert.ToDecimal(shiftRequest.Price);
                else if (DateOnly.Parse(shiftRequest.DateStart).Month == 3)
                     shiftCount[2] += Convert.ToDecimal(shiftRequest.Price);
                else if (DateOnly.Parse(shiftRequest.DateStart).Month == 4)
                     shiftCount[3] += Convert.ToDecimal(shiftRequest.Price);
                else if (DateOnly.Parse(shiftRequest.DateStart).Month == 5)
                     shiftCount[4] += Convert.ToDecimal(shiftRequest.Price);
                else if (DateOnly.Parse(shiftRequest.DateStart).Month == 6)
                     shiftCount[5] += Convert.ToDecimal(shiftRequest.Price);
                else if (DateOnly.Parse(shiftRequest.DateStart).Month == 7)
                     shiftCount[6] += Convert.ToDecimal(shiftRequest.Price);
                else if (DateOnly.Parse(shiftRequest.DateStart).Month == 8)
                     shiftCount[7] += Convert.ToDecimal(shiftRequest.Price);
                else if (DateOnly.Parse(shiftRequest.DateStart).Month == 9)
                     shiftCount[8] += Convert.ToDecimal(shiftRequest.Price);
                else if (DateOnly.Parse(shiftRequest.DateStart).Month == 10)
                     shiftCount[9] += Convert.ToDecimal(shiftRequest.Price);
                else if (DateOnly.Parse(shiftRequest.DateStart).Month == 11)
                     shiftCount[10] += Convert.ToDecimal(shiftRequest.Price);
                else if(DateOnly.Parse(shiftRequest.DateStart).Month == 12)
                    shiftCount[11] += Convert.ToDecimal(shiftRequest.Price);
            }
            listData.MonthProfitData = new List<VisualDataDto>();

            for (int i = 0; i < 12; i++)
            {
                listData.MonthProfitData.Add(new VisualDataDto
                {
                    label = months[i],
                    value = shiftCount[i]
                });
            }

            decimal[] shiftCount2 = new decimal[12];
            foreach (var shiftRequest in result.ShortShiftRequests)
            {
                if (DateOnly.Parse(shiftRequest.DateStart).Month == 1)
                    shiftCount2[0]++;
                else if (DateOnly.Parse(shiftRequest.DateStart).Month == 2)
                    shiftCount2[1]++;
                else if (DateOnly.Parse(shiftRequest.DateStart).Month == 3)
                    shiftCount2[2]++;
                else if (DateOnly.Parse(shiftRequest.DateStart).Month == 4)
                    shiftCount2[3]++;
                else if (DateOnly.Parse(shiftRequest.DateStart).Month == 5)
                    shiftCount2[4]++;
                else if (DateOnly.Parse(shiftRequest.DateStart).Month == 6)
                    shiftCount2[5]++;
                else if (DateOnly.Parse(shiftRequest.DateStart).Month == 7)
                    shiftCount2[6]++;
                else if (DateOnly.Parse(shiftRequest.DateStart).Month == 8)
                    shiftCount2[7]++;
                else if (DateOnly.Parse(shiftRequest.DateStart).Month == 9)
                    shiftCount2[8]++;
                else if (DateOnly.Parse(shiftRequest.DateStart).Month == 10)
                    shiftCount2[9]++;
                else if (DateOnly.Parse(shiftRequest.DateStart).Month == 11)
                    shiftCount2[10]++;
                else if (DateOnly.Parse(shiftRequest.DateStart).Month == 12)
                    shiftCount2[11]++;
            }

            listData.MonthLoadData = new List<VisualDataDto>();

            for (int i = 0; i < 12; i++)
            {
                listData.MonthLoadData.Add(new VisualDataDto
                {
                    label = months[i],
                    value = shiftCount2[i]
                });
            }

            return listData;
        }

        //public class GetShiftByDateDto { public string Date { get; set; } }
    }
}
