using Booking.System.Application.Camps;
using Booking.System.Application.Camps.DTO;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Booking.System.WebApi.Controllers
{
    [ApiController]
    [Route("api/camp")]
    public class CampCardsController : ApiController
    {
        private readonly ICampCardRepository _repository;

        public CampCardsController(IMediator mediator, ICampCardRepository repository)
            : base(mediator)
        {
            _repository = repository;
        }

        [HttpGet("campcards")]
        public async Task<ActionResult<CampCardVm>> GetCampCards()
        {
            var cardsResult = await _repository.GetCampCards();

            return Ok(cardsResult);
        }
        [HttpPost("addcampcard")]
        public async Task<IActionResult> AddCampCard([FromBody] CapmCardDto capmCardDto)
        {
            var userResult = await _repository.CreateCampCard(capmCardDto);

            if (!userResult)
                return new BadRequestObjectResult(userResult);

            return Ok(userResult);
        }
    }
}