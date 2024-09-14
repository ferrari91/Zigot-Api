using MediatR;
using Microsoft.AspNetCore.Mvc;
using Zigot.Core.Application.CommandStack.PersonCommand.CreateCommand;

namespace Zigot_Api.Controllers.Person
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : BaseApiController
    {
        public PersonController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost("register-person")]
        public async Task<IActionResult> RegisterPersonEndPoint([FromBody] PersonCreateRequest request, CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(request, cancellationToken);
            return Success(result);
        }
    }
}
