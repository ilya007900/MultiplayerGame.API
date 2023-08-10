using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MultiplayerGame.API.DataContracts.Games;
using MultiplayerGame.API.Options;
using MultiplayerGame.Application.Games.Commands.MakeMoveCommand;
using MultiplayerGame.Application.Games.Commands.StartGameCommand;
using MultiplayerGame.Application.Games.Contracts;
using MultiplayerGame.Application.Games.Queries.GetGameByIdQuery;

namespace MultiplayerGame.API.Controllers
{
    public class GamesController : BaseController
    {
        private readonly IOptions<GameOptions> _gameOptions;

        public GamesController(IMediator mediator, IOptions<GameOptions> gameOptions) : base(mediator)
        {
            _gameOptions = gameOptions;
        }

        [HttpGet("{gameId}")]
        public async Task<ActionResult<GameDto>> GetById(Guid gameId, CancellationToken cancellationToken)
        {
            var query = new GetGameByIdQuery(gameId);
            var result = await _mediator.Send(query, cancellationToken);
            return ToHttpResult(result);
        }

        [HttpPost]
        public async Task<ActionResult<GameDto>> StartGame(StartGameRequest request)
        {
            var command = new StartGameCommand(
                request.GameRoomId, 
                _gameOptions.Value.FieldWidth,
                _gameOptions.Value.FieldHeight,
                _gameOptions.Value.GameUnitWidth,
                _gameOptions.Value.GameUnitHeight);

            var result = await _mediator.Send(command);
            return ToHttpResult(result);
        }

        [HttpPost("{gameId}/moves")]
        public async Task<ActionResult<GameDto>> MakeMove(Guid gameId, MakeMoveRequest request)
        {
            var command = new MakeMoveCommand(gameId, request.Nickname, request.NewPosition);
            var result = await _mediator.Send(command);
            return ToHttpResult(result);
        }
    }
}
