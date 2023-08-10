using MultiplayerGame.Application.Base;
using MultiplayerGame.Application.GameRooms.Services;
using MultiplayerGame.Domain.GameRooms;

namespace MultiplayerGame.Application.GameRooms.DomainEventsHandlers
{
    internal class PlayerJoinedGameRoomEventHandler :
        IDomainEventHandler<PlayerJoinedGameRoomEvent>
    {
        private readonly IGameRoomEventsBroker _gameRoomEventsBroker;

        public PlayerJoinedGameRoomEventHandler(IGameRoomEventsBroker gameRoomEventsBroker)
        {
            _gameRoomEventsBroker = gameRoomEventsBroker;
        }

        public async Task Handle(PlayerJoinedGameRoomEvent notification, CancellationToken cancellationToken)
        {
            await _gameRoomEventsBroker
                .NotifyPlayerJoined(notification.GameRoomId, notification.Player);
        }
    }
}
