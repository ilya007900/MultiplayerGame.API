using MediatR;
using Microsoft.AspNetCore.Mvc;
using MultiplayerGame.API.DataContracts.Chats;
using MultiplayerGame.Application.Chats.Commands.SendMessageCommand;
using MultiplayerGame.Application.Chats.Contracts;
using MultiplayerGame.Application.Chats.Queries.GetByIdQuery;

namespace MultiplayerGame.API.Controllers
{
    public class ChatsController : BaseController
    {
        public ChatsController(IMediator mediator) : base(mediator)
        {

        }

        [HttpGet("{chatId}")]
        public async Task<ActionResult<ChatDto>> GetById(Guid chatId, CancellationToken cancellationToken)
        {
            var query = new GetByIdQuery(chatId);
            var result = await _mediator.Send(query, cancellationToken);
            return ToHttpResult(result);
        }

        [HttpPost("{chatId}")]
        public async Task<ActionResult<ChatDto>> SendMessage(Guid chatId, SendMessageRequest request)
        {
            var command = new SendMessageCommand(chatId, request.From, request.Text);
            var result = await _mediator.Send(command);
            return ToHttpResult(result);
        }
    }
}
