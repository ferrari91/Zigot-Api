using MediatR;
using Microsoft.AspNetCore.Mvc;
using Zigot_Api.Wrapper.Result;

namespace Zigot_Api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public abstract class BaseApiController : ControllerBase
    {
        protected readonly IMediator Mediator;

        public BaseApiController(IMediator mediator)
        {
            Mediator = mediator;
        }

        protected IActionResult Success<TData>(TData data)
        {
            var result = new BaseResult<TData>(data);
            return Ok(result);
        }
    }
}
