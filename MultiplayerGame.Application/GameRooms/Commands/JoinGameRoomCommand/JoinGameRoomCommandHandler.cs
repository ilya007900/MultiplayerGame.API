using MultiplayerGame.Application.Base;
using MultiplayerGame.Application.GameRooms.Contracts;
using MultiplayerGame.Domain.GameRooms;
using MultiplayerGame.Domain.SharedKernel;

namespace MultiplayerGame.Application.GameRooms.Commands.JoinGameRoomCommand
{
    public class JoinGameRoomCommandHandler : IOperationHandler<JoinGameRoomCommand, GameRoomDto>
    {
        private readonly IGameRoomRepository _gameRoomRepository;

        public JoinGameRoomCommandHandler(IGameRoomRepository gameRoomRepository)
        {
            _gameRoomRepository = gameRoomRepository;
        }

        public async Task<OperationResult<GameRoomDto>> Handle(JoinGameRoomCommand request, CancellationToken cancellationToken)
        {
            var gameRoom = await _gameRoomRepository.FindById(request.GameRoomId, cancellationToken);
            if (gameRoom == null)
            {
                return OperationResultFactory.CreateFailure<GameRoomDto>("Game room not found.");
            }

            var player = Player.Create(request.Nickname, request.Color);

            var result = gameRoom.Join(player);

            if (result.IsFailure)
            {
                return OperationResultFactory.CreateFailure<GameRoomDto>(result.Error);
            }

            return OperationResultFactory.CreateSucess(Mapper.From(gameRoom));
        }
    }
}
