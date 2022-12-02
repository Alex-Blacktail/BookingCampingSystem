using System.Net;
using Booking.System.Application.Identity;
using Booking.System.Application.Identity.DTO;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Booking.System.WebApi.Controllers
{
    [ApiController]
    [Route("api/authentication")]
    public abstract class AuthController : ApiController
    {
        private readonly IUserAuthenticationRepository _repository;

        protected AuthController(IMediator mediator, IUserAuthenticationRepository repository) 
            : base(mediator)
        {
            _repository = repository;
        }

        [HttpPost]

        public async Task<IActionResult> RegisterUser(UserRegistrationDto userRegistration)
        {
            var userResult = await _repository.RegisterUserAsync(userRegistration);

            if(!userResult.Succeeded)
            {
                return StatusCode(201);
            }

            return  new BadRequestObjectResult(userResult);
        }
    }
}