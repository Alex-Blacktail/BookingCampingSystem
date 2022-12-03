using System.Net;
using Booking.System.Application.Identity;
using Booking.System.Application.Identity.DTO;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Booking.System.WebApi.Controllers
{
    [ApiController]
    [Route("api/authentication")]
    public class AuthController : ApiController
    {
        private readonly IUserAuthenticationRepository _repository;

        public AuthController(IMediator mediator, IUserAuthenticationRepository repository)
            : base(mediator)
        {
            _repository = repository;
        }

        [HttpPost("register/superadmin")]
        public async Task<IActionResult> RegisterUser(UserRegistrationDto userRegistration)
        {
            var userResult = await _repository.RegisterUserAsync(userRegistration);

            if (!userResult.Succeeded)
                return new BadRequestObjectResult(userResult);

            return StatusCode(201);
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

            return Ok(new { Token = await _repository.CreateTokenAsync() });
        }
    }
}