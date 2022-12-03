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

namespace Booking.System.Application.Identity
{
    public class CampCardRepository : ICampCardRepository
    {
        private readonly IMapper _mapper;

        private readonly CampDbContext _campDbContext;

        public CampCardRepository(IMapper mapper, CampDbContext campDbContext)
        {
            _mapper = mapper;
            _campDbContext = campDbContext;
        }
        public async Task<CampCardVm> GetCampCards()
        {
            var camps = await _campDbContext.Camps.ToListAsync();

            List<CapmCardDto> CapmCardDtoList = new List<CapmCardDto>();
            foreach (var camp in camps)
            {
                var dto = new CapmCardDto();
                dto.Name = camp.Name;
                dto.ShortName = camp.ShortName;
                Address adr = await _campDbContext.Addresses.FirstAsync(x => x.AddressId == camp.AddressId);
                dto.Address = adr.AddressContent;
                dto.Capacity = camp.Capacity;
                dto.NumberOfBuildings = camp.NumberOfBuildings;
                dto.About = camp.About;
                dto.Food = camp.Food;
                dto.WebsiteLink = camp.WebsiteLink;
                dto.LegalEntity = camp.LegalEntity;
                dto.TheAreaOfTheLand = camp.TheAreaOfTheLand;

                dto.ChildsAgeStart = camp.ChildsAgeStart;
                dto.ChildsAgeEnd = camp.ChildsAgeEnd;

                dto.ChildrensHolidayCertificate = camp.ChildrensHolidayCertificate;
                dto.EducationalLicense = camp.EducationalLicense;
                dto.MedicalLicense = camp.MedicalLicense;

                if (_campDbContext.Features.Count() > 0) {
                    foreach (var feature in _campDbContext.Features.Where(f => f.CampId == camp.CampId))
                    {
                        dto.Features.Add(_mapper.Map<FeatureDto>(feature));
                    }
                }
                var workingMode = _campDbContext.WorkingModes.First(w => w.WorkingModeId == camp.WorkingModeId);
                dto.WorkingModeDto = _mapper.Map<WorkingModeDto>(workingMode);

                var shifts = await _campDbContext.Shifts.ToListAsync();
                foreach (var shift in shifts)
                {
                    var shiftsTypes = new List<ShiftType>();
                    foreach (var shiftType in _campDbContext.ShiftByShiftTypes.ToList())
                    {
                        shiftsTypes.Add(_campDbContext.ShiftTypes
                            .First(x => x.ShiftTypeId == shiftType.ShiftTypeId));
                    }

                    List<ShiftTypeDto> shiftTypeDtos = new List<ShiftTypeDto>();
                    foreach (var shiftType in shiftsTypes)
                        shiftTypeDtos.Add(_mapper.Map<ShiftTypeDto>(shiftType));

                    dto.Shifts.Add(new ShiftDto
                    {
                        DateStart = shift.DateStart,
                        DateEnd = shift.DateEnd,
                        Name = shift.Name,
                        ShiftTypeDtos = shiftTypeDtos
                    });
                }
                CapmCardDtoList.Add(dto);
            }
            return new CampCardVm { capmCardDtos = CapmCardDtoList };
        }
    }
}
