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
using Booking.System.Application.LocalAdmins.DTO;
using System.Collections.Generic;

namespace Booking.System.Application.LocalAdmins
{
    public class LocalAdminRepository : ILocalAdminRepository
    {
        private readonly IMapper _mapper;

        private readonly CampDbContext _campDbContext;

        public LocalAdminRepository(IMapper mapper, CampDbContext campDbContext)
        {
            _mapper = mapper;
            _campDbContext = campDbContext;
        }


        public async Task<List<CampInfoDto>> LookRequest(string id)
        {
            List<CampInfoDto> dtoList = new List<CampInfoDto>();
            try
            {
                //var localAdmin = _campDbContext.LocalAdministrators.First(x=>x.LocalAdministratorId == id);

                var localAdmin = _campDbContext.LocalAdministrators.Include(x => x.IdCamps).ToList();

                //var camp = _campDbContext.Camps.Include(x=>x.IdLocalAdmins == localAdmin).FirstOrDefault();

                var camp = localAdmin.First(x=>x.LocalAdministratorId == id).IdCamps.First();
                //var camp = _campDbContext.Camps.Include(p => p.IdLocalAdmins).First();
                // var camp = _campDbContext.Camps.Include(x=>x.CampId == localAdmin.IdCamps.First().CampId).FirstOrDefault();


                    var shifts = _campDbContext.Shifts.Where(x => x.CampId == camp.CampId).ToList();

                    //_campDbContext.ShiftByShiftTypes.Include(x=>x.Shift == shifts).ToList();
                    var shiftByShiftTypes = new List<ShiftByShiftType>();

                    foreach (var shift in shifts)
                    {
                        shiftByShiftTypes.AddRange(_campDbContext.ShiftByShiftTypes.Where(x => x.ShiftId == shift.ShiftId).ToList());
                    }

                    var shiftRequests = new List<ShiftRequest>();

                    //var requests = _campDbContext.ShiftRequests.Where(x=>x.ShiftByShiftTypeId ==)
                    foreach (var shiftByShiftType in shiftByShiftTypes)
                    {
                        shiftRequests.AddRange(_campDbContext.ShiftRequests.Where(x => x.ShiftByShiftTypeId == shiftByShiftType.ShiftByShiftTypeId).ToList());
                    }
                    foreach (var request in shiftRequests)
                    {
                        CampInfoDto dto = new CampInfoDto();

                        dto.ChildName = _campDbContext.Children.First(x=>x.ChildId == request.ChildId).Name;
                        dto.ChildSurnaname = _campDbContext.Children.First(x => x.ChildId == request.ChildId).Surname;
                        dto.ChildPatronomyc = _campDbContext.Children.First(x => x.ChildId == request.ChildId).Patronymic;
                        dto.ChildPhone = _campDbContext.Children.First(x => x.ChildId == request.ChildId).PhoneNumber;

                        dto.ParentName = _campDbContext.Parents.First(x => x.ParentId == request.ParentId).Name;
                        dto.ParentSurnaname = _campDbContext.Parents.First(x => x.ParentId == request.ParentId).Surname;
                        dto.ParentPatronomyc = _campDbContext.Parents.First(x => x.ParentId == request.ParentId).Patronymic;
                        dto.ParentPhone = _campDbContext.Children.First(x => x.ChildId == request.ChildId).PhoneNumber;

                        var sbst = _campDbContext.ShiftByShiftTypes.First(x => x.ShiftByShiftTypeId == request.ShiftByShiftTypeId);

                        var shift = _campDbContext.Shifts.First(x => x.ShiftId == sbst.ShiftId);

                        var campdto = _campDbContext.Camps.First(x => x.CampId == shift.CampId);

                        var campaddres = _campDbContext.Addresses.First(x => x.AddressId == campdto.AddressId);
                        dto.CampName = campdto.Name;
                        dto.CampAddress = campaddres.AddressContent;
                        dto.Price = request.Price.ToString();
                        dto.RequestId = request.RequestId;
                        dto.ShiftInfo = shift.Name + " " + shift.DateStart + " - " + shift.DateEnd + " : " + _campDbContext.ShiftTypes.First(x => x.ShiftTypeId == sbst.ShiftTypeId).Name;
                       
                        dtoList.Add(dto);
                    
                }

            }
            catch (Exception ex) { throw ex; }
            return dtoList;
        }
    }
}
