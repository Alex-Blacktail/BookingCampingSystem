using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Booking.System.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public abstract class ApiController : ControllerBase
    {
        protected IMediator _mediator;

        protected ApiController(IMediator mediator) 
        { 
            _mediator = mediator;
        }
    }
}