using MediatR;
using Microsoft.AspNetCore.Mvc;
using Booking.System.Application.ShiftsRequests;
using Booking.System.Application.ShiftsRequests.DTO;

namespace Booking.System.WebApi.Controllers
{
    [ApiController]
    [Route("api/shiftrequest")]
    public class ShiftRequestController : ApiController
    {
        private readonly IShiftRequestRepository _repository;

        public ShiftRequestController(IMediator mediator, IShiftRequestRepository repository)
            : base(mediator)
        {
            _repository = repository;
        }

        /// <summary>
        /// Создать заявку в лагерь
        /// </summary>
        /// <param name="createRequestDto"></param>
        /// <returns></returns>
        [HttpPost("createrequest")]
        public async Task<ActionResult<GetShiftRequestDto>> CreateRequest(CreateRequestDto createRequestDto)
        {
            var cardsResult = await _repository.CreateRequest(createRequestDto);

            return Ok(cardsResult);
        }

        //[HttpGet("all")]
        //public async Task<ActionResult> GetAllShiftRequests()
        //{
        //}

        //[HttpGet]
        //public async Task<ActionResult> GetFreeShifts()
        //{

        //}

    }
}