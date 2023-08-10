using MultiplayerGame.Application.Base;
using MultiplayerGame.Application.Games.Contracts;
using MultiplayerGame.Domain.Chats;
using MultiplayerGame.Domain.GameRooms;
using MultiplayerGame.Domain.Games;

namespace MultiplayerGame.Application.Games.Commands.StartGameCommand
{
    public class StartGameCommandHandler : IOperationHandler<StartGameCommand, GameDto>
    {
        private readonly IGameRoomRepository _gameRoomRepository;
        private readonly IGameRepository _gameRepository;
        private readonly IChatRepository _chatRepository;

        public StartGameCommandHandler(
            IGameRoomRepository gameRoomRepository,
            IGameRepository gameRepository,
            IChatRepository chatRepository)
        {
            _gameRoomRepository = gameRoomRepository;
            _gameRepository = gameRepository;
            _chatRepository = chatRepository;
        }

        public async Task<OperationResult<GameDto>> Handle(StartGameCommand request, CancellationToken cancellationToken)
        {
            var gameRoom = await _gameRoomRepository.GetById(request.GameRoomId);

            var fieldSize = new Area(request.FieldWidth, request.FieldHeight);
            var unitSize = new Area(request.GameUnitWidth, request.GameUnitHeight);
            var game = gameRoom.StartGame(fieldSize, unitSize);
            var chat = game.StartChat();

            await _gameRepository.Add(game);
            await _chatRepository.Add(chat);

            return OperationResultFactory.CreateSucess(Mapper.From(game));
        }
    }
}
