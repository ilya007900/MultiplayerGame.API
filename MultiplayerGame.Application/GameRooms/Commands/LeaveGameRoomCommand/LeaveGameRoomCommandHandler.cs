using MediatR;
using MultiplayerGame.Application.Base;
using MultiplayerGame.Application.GameRooms.Contracts;
using MultiplayerGame.Domain.GameRooms;

namespace MultiplayerGame.Application.GameRooms.Commands.LeaveGameRoomCommand
{
    public class LeaveGameRoomCommandHandler : IOperationHandler<LeaveGameRoomCommand, GameRoomDto>
    {
        private readonly IGameRoomRepository _gameRoomRepository;

        public LeaveGameRoomCommandHandler(IGameRoomRepository gameRoomRepository)
        {
            _gameRoomRepository = gameRoomRepository;
        }

        async Task<OperationResult<GameRoomDto>> IRequestHandler<LeaveGameRoomCommand, OperationResult<GameRoomDto>>.Handle(LeaveGameRoomCommand request, CancellationToken cancellationToken)
        {
            var gameRoom = await _gameRoomRepository.GetById(request.GameRoomId, CancellationToken.None);

            var result = gameRoom.Leave(request.Nickname);
            if (result.IsFailure)
            {
                return OperationResultFactory.CreateFailure<GameRoomDto>(result.Error);
            }

            return OperationResultFactory.CreateSucess(Mapper.From(gameRoom));
        }
    }
}
