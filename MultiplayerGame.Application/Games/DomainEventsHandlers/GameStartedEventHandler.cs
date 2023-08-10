using MultiplayerGame.Application.Base;
using MultiplayerGame.Application.GameRooms.Services;
using MultiplayerGame.Domain.Games;

namespace MultiplayerGame.Application.Games.DomainEventsHandlers
{
    public class GameStartedEventHandler : IDomainEventHandler<GameStartedEvent>
    {
        private readonly IGameRoomEventsBroker _gameRoomEventsBroker;

        public GameStartedEventHandler(IGameRoomEventsBroker gameRoomEventsBroker)
        {
            _gameRoomEventsBroker = gameRoomEventsBroker;
        }

        public async Task Handle(
            GameStartedEvent notification, CancellationToken cancellationToken)
        {
            await _gameRoomEventsBroker.NotifyGameStarted(notification.GameRoomId, notification.GameId);
        }
    }
}
