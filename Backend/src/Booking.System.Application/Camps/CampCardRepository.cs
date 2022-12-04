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

                if (_campDbContext.Features.Where(f => f.CampId == camp.CampId).Count() > 0)
                {
                    foreach (var feature in _campDbContext.Features.Where(f => f.CampId == camp.CampId))
                    {
                        dto.Features.Add(_mapper.Map<FeatureDto>(feature));
                    }
                }
                // var workingMode = _campDbContext.WorkingModes.First(w => w.WorkingModeId == camp.WorkingModeId);
                // dto.WorkingModeDto = _mapper.Map<WorkingModeDto>(workingMode);
                dto.WorkingModeDto = _campDbContext.WorkingModes.First(w => w.WorkingModeId == camp.WorkingModeId).WorkingModeString;
                var shifts = await _campDbContext.Shifts.Where(x=>x.CampId==camp.CampId).ToListAsync();
                foreach (var shift in shifts)
                {
                    var shiftsTypes = new List<ShiftType>();
                    foreach (var shiftbyshiftType in _campDbContext.ShiftByShiftTypes.Where(x=>x.ShiftId==shift.ShiftId).ToList())
                    {
                        shiftsTypes.Add(_campDbContext.ShiftTypes
                            .First(x => x.ShiftTypeId == shiftbyshiftType.ShiftTypeId));
                    }

                    List<ShiftTypeDto> shiftTypeDtos = new List<ShiftTypeDto>();
                    foreach (var shiftType in shiftsTypes)
                    {

                        ShiftByShiftType shiftByShiftType = _campDbContext.ShiftByShiftTypes
                            .First(x => x.ShiftTypeId == shiftType.ShiftTypeId && x.ShiftId == shift.ShiftId);

                        shiftTypeDtos.Add(new ShiftTypeDto
                        {
                            Name = shiftType.Name,
                            Price = shiftByShiftType.Price,
                            ShiftByShiftTypeId = shiftByShiftType.ShiftByShiftTypeId
                        });
                    }
                    //shiftTypeDtos.Add(_mapper.Map<ShiftTypeDto>(shiftType));

                    dto.Shifts.Add(new ShiftDto
                    {
                        DateStart = shift.DateStart.Year.ToString() +"-"+shift.DateStart.Month.ToString() +"-"+ shift.DateStart.Day.ToString(),
                        DateEnd = shift.DateEnd.Year.ToString() + "-" + shift.DateEnd.Month.ToString() + "-" + shift.DateEnd.Day.ToString(),
                        Name = shift.Name,
                        ShiftTypeDtos = shiftTypeDtos
                    });
                }
                CapmCardDtoList.Add(dto);
            }
            return new CampCardVm { capmCardDtos = CapmCardDtoList };
        }

        public async Task<bool> CreateCampCard(CapmCardDto CampDto)
        {
            try
            {
                Address adr = new Address
                {
                    //TODO: проспилить страну
                    AddressContent = CampDto.Address
                };
                _campDbContext.Addresses.Add(adr);
                //var workingMode = _mapper.Map<WorkingMode>(CampDto.WorkingModeDto);
                //_campDbContext.WorkingModes.Add(workingMode);

                var workingMode = new WorkingMode
                {
                    WorkingModeString = CampDto.WorkingModeDto
                };
                _campDbContext.WorkingModes.Add(workingMode);
             
                _campDbContext.SaveChanges();

                var camp = new Camp();
                camp.Name = CampDto.Name;
                camp.ShortName = CampDto.ShortName;
                camp.Capacity = CampDto.Capacity;
                camp.NumberOfBuildings = CampDto.NumberOfBuildings;
                camp.About = CampDto.About;
                camp.Food = CampDto.Food;
                camp.WebsiteLink = CampDto.WebsiteLink;
                camp.LegalEntity = CampDto.LegalEntity;
                camp.TheAreaOfTheLand = CampDto.TheAreaOfTheLand;
                camp.ChildsAgeStart = CampDto.ChildsAgeStart;
                camp.ChildsAgeEnd = CampDto.ChildsAgeEnd;
                camp.ChildrensHolidayCertificate = CampDto.ChildrensHolidayCertificate;
                camp.EducationalLicense = CampDto.EducationalLicense;
                camp.MedicalLicense = CampDto.MedicalLicense;
                camp.AddressId = adr.AddressId;
                camp.WorkingModeId = workingMode.WorkingModeId;
               
                _campDbContext.Camps.Add(camp);
                _campDbContext.SaveChanges();
                if (CampDto.Features.Count() > 0)
                {
                    foreach (var feature in CampDto.Features)
                    {
                        _campDbContext.Features.Add(new Feature
                        {
                            CampId = camp.CampId,
                            Name = feature.Name
                        });
                    }
                }

                if (_campDbContext.ShiftTypes.Count() == 0)
                {
                    _campDbContext.ShiftTypes.Add(new ShiftType { Name = "Детский лагерь" });
                    _campDbContext.ShiftTypes.Add(new ShiftType { Name = "Санаторий" });
                    _campDbContext.ShiftTypes.Add(new ShiftType { Name = "Палаточный лагерь" });
                    _campDbContext.ShiftTypes.Add(new ShiftType { Name = "Военно-патриотический лагерь" });

                    _campDbContext.SaveChanges();
                }
                if (CampDto.Shifts.Count > 0)
                {
                    foreach (var shiftdto in CampDto.Shifts)
                    {
                        string[] StartDates = shiftdto.DateStart.Split("-");
                        string[] EndDates = shiftdto.DateEnd.Split("-");

                        var shift = new Shift
                        {
                            Name = shiftdto.Name,
                            DateStart = new DateOnly(int.Parse(StartDates[0]), int.Parse(StartDates[1]), int.Parse(StartDates[2])),
                            DateEnd = new DateOnly(int.Parse(EndDates[0]), int.Parse(EndDates[1]), int.Parse(EndDates[2])),
                            CampId = camp.CampId
                        };
                        _campDbContext.Shifts.Add(shift);
                        _campDbContext.SaveChanges();
                        if (shiftdto.ShiftTypeDtos.Count > 0)
                        {
                            foreach (var shiftTypeDto in shiftdto.ShiftTypeDtos)
                            {
                                
                                var shiftType =  _campDbContext.ShiftTypes
                                    .FirstOrDefault(x => x.Name == shiftTypeDto.Name);
                                if (shiftType != null)
                                {
                                    var shiftByShiftType = new ShiftByShiftType
                                    {
                                        ShiftId = shift.ShiftId,
                                        ShiftTypeId = shiftType.ShiftTypeId,
                                        Price = shiftTypeDto.Price
                                    };
                                    _campDbContext.ShiftByShiftTypes.Add(shiftByShiftType);

                                    _campDbContext.SaveChanges();
                                }
                                
                            }
                        }
                        _campDbContext.SaveChanges();
                    }
                }
            }
            catch(Exception ex) { throw ex;  }
            return true;
        }
    }
}
