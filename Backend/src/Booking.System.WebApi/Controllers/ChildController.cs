using Booking.System.Application.Childs.DTO;
using Booking.System.Application.Childs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Booking.System.WebApi.Controllers
{
    [ApiController]
    [Route("api/child")]
    public class ChildController : ApiController
    {
        private readonly IChildRepository _repository;

        public ChildController(IMediator mediator, IChildRepository repository)
            : base(mediator)
        {
            _repository = repository;
        }
        [HttpPost("addchildinfo")]
        public async Task<IActionResult> AddChildInfo([FromBody] ChildDto childDto)
        {
            var userResult = await _repository.CreateChild(childDto);

            if (!userResult)
                return new BadRequestObjectResult(userResult);

            return Ok(userResult);
        }
    }
}