using System.Net;
using Booking.System.Application.Camps;
using Booking.System.Application.Camps.DTO;
using Booking.System.Application.Identity;
using Booking.System.Application.Identity.DTO;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Booking.System.WebApi.Controllers
{
    [ApiController]
    [Route("api/authentication")]
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
    }
}