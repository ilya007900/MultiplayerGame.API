using MultiplayerGame.Application.Base;
using MultiplayerGame.Application.GameRooms.Services;
using MultiplayerGame.Domain.GameRooms;

namespace MultiplayerGame.Application.GameRooms.DomainEventsHandlers
{
    public class PlayerLeftGameRoomEventHandler :
        IDomainEventHandler<PlayerLeftGameRoomEvent>
    {
        private readonly IGameRoomEventsBroker _gameRoomEventsBroker;

        public PlayerLeftGameRoomEventHandler(IGameRoomEventsBroker gameRoomEventsBroker)
        {
            _gameRoomEventsBroker = gameRoomEventsBroker;
        }

        public async Task Handle(PlayerLeftGameRoomEvent notification, CancellationToken cancellationToken)
        {
            await _gameRoomEventsBroker
                .NotifyPlayerLeft(notification.GameRoomId, notification.Player);
        }
    }
}
