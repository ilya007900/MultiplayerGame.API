using MediatR;
using Microsoft.AspNetCore.Mvc;
using MultiplayerGame.Application.Base;

namespace MultiplayerGame.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseController : ControllerBase
    {
        protected readonly IMediator _mediator;

        public BaseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        protected ActionResult<TResult> ToHttpResult<TResult>(OperationResult<TResult> operationResult)
        {
            if (operationResult.Failure)
            {
                return BadRequest(operationResult.Errors);
            }

            return operationResult.Result;
        }
    }
}
