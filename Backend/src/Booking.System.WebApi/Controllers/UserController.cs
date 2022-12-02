using MediatR;

namespace Booking.System.WebApi.Controllers
{
    public class UserController : ApiController
    {
        public UserController(IMediator mediator) : base(mediator)
        {
        }
    }
}
