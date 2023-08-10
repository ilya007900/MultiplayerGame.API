using MultiplayerGame.Application.Base;
using MultiplayerGame.Application.Games.Contracts;
using MultiplayerGame.Domain.Games;

namespace MultiplayerGame.Application.Games.Commands.MakeMoveCommand
{
    public class MakeMoveCommandHandler : IOperationHandler<MakeMoveCommand, GameDto>
    {
        private readonly IGameRepository _gameRepository;

        public MakeMoveCommandHandler(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public async Task<OperationResult<GameDto>> Handle(MakeMoveCommand request, CancellationToken cancellationToken)
        {
            var game = await _gameRepository.GetById(request.GameId);

            var newPosition = new Position(request.NewPosition.X, request.NewPosition.Y);

            var result = game.MakeMove(request.PlayerNickname, newPosition);
            if (result.IsFailure)
            {
                return OperationResultFactory.CreateFailure<GameDto>(result.Error);
            }

            return OperationResultFactory.CreateSucess(Mapper.From(game));
        }
    }
}
