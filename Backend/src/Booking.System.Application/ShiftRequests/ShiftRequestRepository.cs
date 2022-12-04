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
        public async Task<ShiftRequestDto> GetRequestInfo()
        {
           
            return new ShiftRequestDto {  };
        }

    }
}
