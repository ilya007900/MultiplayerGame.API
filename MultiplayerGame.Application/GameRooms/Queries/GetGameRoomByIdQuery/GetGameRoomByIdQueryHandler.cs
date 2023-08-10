using MultiplayerGame.Application.Base;
using MultiplayerGame.Application.GameRooms.Contracts;
using MultiplayerGame.Domain.GameRooms;

namespace MultiplayerGame.Application.GameRooms.Queries.GetGameRoomByIdQuery
{
    public class GetGameRoomByIdQueryHandler : IOperationHandler<GetGameRoomByIdQuery, GameRoomDto>
    {
        private readonly IGameRoomRepository _gameRoomRepository;

        public GetGameRoomByIdQueryHandler(IGameRoomRepository gameRoomRepository)
        {
            _gameRoomRepository = gameRoomRepository;
        }

        public async Task<OperationResult<GameRoomDto>> Handle(
            GetGameRoomByIdQuery request, CancellationToken cancellationToken)
        {
            var gameRoom = await _gameRoomRepository.GetById(request.Id, cancellationToken);

            return OperationResultFactory.CreateSucess(Mapper.From(gameRoom));
        }
    }
}
