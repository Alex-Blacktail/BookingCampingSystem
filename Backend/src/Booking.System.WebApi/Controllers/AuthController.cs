using System.Net;
using Booking.System.Application.Identity;
using Booking.System.Application.Identity.DTO;
using MediatR;
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

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser(UserRegistrationDto userRegistration)
        {
            var userResult = await _repository.RegisterUserAsync(userRegistration);

            if(!userResult.Succeeded)
                return StatusCode(201);

            return Ok(userResult);
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