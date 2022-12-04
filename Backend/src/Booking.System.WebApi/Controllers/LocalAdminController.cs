using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Data;
using Booking.System.Application.LocalAdmins.DTO;
using Booking.System.Application.LocalAdmins;
namespace Booking.System.WebApi.Controllers
{
    [ApiController]
    [Route("api/localadmin")]
    public class LocalAdminController : ApiController
    {
        private readonly ILocalAdminRepository _repository;

        public LocalAdminController(IMediator mediator, ILocalAdminRepository repository)
            : base(mediator)
        {
            _repository = repository;
        }
        [HttpGet("getcampsinfolocal/{id}")]
        public async Task<ActionResult<List<CampInfoDto>>> GetCampsInfoLocal(string id)
        {
            var cardsResult = await _repository.LookRequest(id);

            return Ok(cardsResult);
        }

    }
}