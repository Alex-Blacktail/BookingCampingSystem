using Booking.System.Application.Childs.DTO;
using Booking.System.Application.Childs;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Data;

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
        /// <summary>
        /// Добавить информацию о ребенке
        /// </summary>
        /// <param name="childDto"></param>
        /// <returns></returns>
        // [Authorize(Roles = "parent")]
        [HttpPost("addchildinfo")]
        [Authorize(Roles = "parent")]
        public async Task<IActionResult> AddChildInfo([FromBody] ChildDto childDto)
        {
            var userResult = await _repository.CreateChild(childDto);

            if (!userResult)
                return new BadRequestObjectResult(userResult);

            return Ok(userResult);
        }
        /// <summary>
        /// Удалить данные о ребенке
        /// </summary>
        /// <param name="removeChildInfoDto"></param>
        /// <returns></returns>
        [HttpDelete("removechildinfo")]
        [Authorize(Roles = "parent")]
        public async Task<IActionResult> RemoveChildInfo([FromBody] RemoveChildInfoDto removeChildInfoDto)
        {
            var userResult = await _repository.RemoveChildInfo(removeChildInfoDto);

            if (!userResult)
                return new BadRequestObjectResult(userResult);

            return Ok(userResult);
        }

       
      
    }
}