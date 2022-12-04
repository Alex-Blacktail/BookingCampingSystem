using Booking.System.Application.Parents.DTO;
using Booking.System.Application.Parents;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Booking.System.Application.Camps.DTO;
using Microsoft.AspNetCore.Authorization;

namespace Booking.System.WebApi.Controllers
{
    [ApiController]
    [Route("api/parentlookup")]
    public class ParentLookupController : ApiController
    {
        private readonly IParentRepository _repository;

        public ParentLookupController(IMediator mediator, IParentRepository repository)
            : base(mediator)
        {
            _repository = repository;
        }

        /// <summary>
        /// Получить данные о родителе
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("parentlookupinfo/{id}")]
        [Authorize(Roles = "parent")]
        public async Task<ActionResult<ParentDto>> GetParentInfo(string id)
        {
            var cardsResult = await _repository.GetParentAndChildInfo(id);

            return Ok(cardsResult);
        }
        
    }
}