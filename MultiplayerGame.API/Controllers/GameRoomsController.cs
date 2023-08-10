using MediatR;
using Microsoft.AspNetCore.Mvc;
using MultiplayerGame.API.DataContracts.GameRooms;
using MultiplayerGame.Application.GameRooms.Commands.CreateGameRoomCommand;
using MultiplayerGame.Application.GameRooms.Commands.JoinGameRoomCommand;
using MultiplayerGame.Application.GameRooms.Commands.LeaveGameRoomCommand;
using MultiplayerGame.Application.GameRooms.Contracts;
using MultiplayerGame.Application.GameRooms.Queries.GetGameRoomByIdQuery;

namespace MultiplayerGame.API.Controllers
{
    public class GameRoomsController : BaseController
    {
        public GameRoomsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public async Task<ActionResult<GameRoomDto>> CreateGameRoom(CreateGameRoomRequest request)
        {
            var command = new CreateGameRoomCommand(request.Nickname, request.Color);
            var result = await _mediator.Send(command);
            return ToHttpResult(result);
        }

        [HttpPost("{gameRoomId}/players")]
        public async Task<ActionResult<GameRoomDto>> JoinGameRoom(Guid gameRoomId, JoinGameRoomRequest request)
        {
            var command = new JoinGameRoomCommand(gameRoomId, request.Nickname, request.Color);
            var result = await _mediator.Send(command);
            return ToHttpResult(result);
        }

        [HttpDelete("{gameRoomId}/players/{nickname}")]
        public async Task<ActionResult<GameRoomDto>> LeaveGameRoom(Guid gameRoomId, string nickname)
        {
            var command = new LeaveGameRoomCommand(gameRoomId, nickname);
            var result = await _mediator.Send(command);
            return ToHttpResult(result);
        }

        [HttpGet("{gameRoomId}")]
        public async Task<ActionResult<GameRoomDto>> GetById(Guid gameRoomId, CancellationToken cancellationToken)
        {
            var request = new GetGameRoomByIdQuery(gameRoomId);
            var response = await _mediator.Send(request, cancellationToken);
            return ToHttpResult(response);
        }
    }
}
