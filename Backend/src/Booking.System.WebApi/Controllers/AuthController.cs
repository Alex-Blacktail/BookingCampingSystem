using System.Net;
using Booking.System.Application.Identity;
using Booking.System.Application.Identity.DTO;
using Booking.System.Domain.Identity;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Booking.System.WebApi.Controllers
{
    [ApiController]
    [Route("api/authentication")]
    public class AuthController : ApiController
    {
        private readonly IUserAuthenticationRepository _repository;

        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AuthController(IMediator mediator, IUserAuthenticationRepository repository, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
            : base(mediator)
        {
            _repository = repository;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [HttpPost("register/superadmin")]
        public async Task<IActionResult> RegisterUser(UserRegistrationDto userRegistration)
        {
            var userResult = await _repository.RegisterUserAsync(userRegistration);

            if (!userResult.Succeeded)
                return new BadRequestObjectResult(userResult);

            var user = await _userManager.FindByEmailAsync(userRegistration.Email);
            return Ok(new { userId = user.Id });
        }
        [HttpPost("register/parent")]
        public async Task<IActionResult> RegisterParent(ParentRegistrationDto parentRegistrationDto)
        {
            var userResult = await _repository.RegisterParentAsync(parentRegistrationDto);

            if (!userResult.Succeeded)
                return new BadRequestObjectResult(userResult);
            
            return StatusCode(201);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Authenticate([FromBody] UserLoginDto user)
        {
            var isValid = await _repository.ValidateUserAsync(user);
            if (!isValid)
                return Unauthorized();

            var userData = await _userManager.FindByNameAsync(user.UserName);
            var userRoles = await _userManager.GetRolesAsync(userData);
            return Ok(
                new
                {
                    token = await _repository.CreateTokenAsync(),
                    userId = userData.Id,
                    role = userRoles.FirstOrDefault()
                }) ;
        }
    }
}