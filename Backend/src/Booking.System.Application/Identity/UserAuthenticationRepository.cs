using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;

using Booking.System.Domain.Identity;
using Booking.System.Application.Identity.DTO;

using AutoMapper;

namespace Booking.System.Application.Identity
{
    public class UserAuthenticationRepository : IUserAuthenticationRepository
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        private AppUser? _user;

        public UserAuthenticationRepository(UserManager<AppUser> userManager, IConfiguration configuration, IMapper mapper)
        {
            _userManager = userManager;
            _configuration = configuration;
            _mapper = mapper;
        }

        public async Task<IdentityResult> RegisterUserAsync(UserRegistrationDto userRetistrationDto)
        {
            var user = _mapper.Map<AppUser>(userRetistrationDto);
            var result = await _userManager.CreateAsync(user, userRetistrationDto.Password);
            return result;
        }
    }
}
