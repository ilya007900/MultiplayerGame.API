using MultiplayerGame.Application.Base;
using MultiplayerGame.Application.GameRooms.Contracts;
using MultiplayerGame.Domain.GameRooms;
using MultiplayerGame.Domain.SharedKernel;

namespace MultiplayerGame.Application.GameRooms.Commands.CreateGameRoomCommand
{
    public class CreateGameRoomCommandHandler : IOperationHandler<CreateGameRoomCommand, GameRoomDto>
    {
        private readonly IGameRoomRepository _gameRoomRepository;

        public CreateGameRoomCommandHandler(
            IGameRoomRepository gameRoomRepository)
        {
            _gameRoomRepository = gameRoomRepository;
        }

        public async Task<OperationResult<GameRoomDto>> Handle(CreateGameRoomCommand request, CancellationToken cancellationToken)
        {
            var player = Player.Create(request.Nickname, request.Color);
            var gameRoom = GameRoom.Create(player);

            gameRoom = await _gameRoomRepository.Add(gameRoom);

            return OperationResultFactory.CreateSucess(Mapper.From(gameRoom));
        }
    }
}
