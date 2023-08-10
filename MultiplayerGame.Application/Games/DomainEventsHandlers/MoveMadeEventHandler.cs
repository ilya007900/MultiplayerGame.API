using MultiplayerGame.Application.Base;
using MultiplayerGame.Application.Games.Services;
using MultiplayerGame.Domain.Games;

namespace MultiplayerGame.Application.Games.DomainEventsHandlers
{
    public class MoveMadeEventHandler : IDomainEventHandler<MoveMadeEvent>
    {
        private readonly IGameEventsBroker _gameEventsBroker;
        private readonly IMovementRepository _movementRepository;

        public MoveMadeEventHandler(
            IGameEventsBroker gameEventsBroker,
            IMovementRepository movementRepository)
        {
            _gameEventsBroker = gameEventsBroker;
            _movementRepository = movementRepository;
        }

        public async Task Handle(MoveMadeEvent notification, CancellationToken cancellationToken)
        {
            await _gameEventsBroker.NotifyMoveMade(notification.GameId, notification.GameUnit, notification.NextMove);

            var movement = new Movement(
                notification.GameId,
                notification.GameUnit.Player.Nickname,
                notification.OldPosition,
                notification.GameUnit.Position);

            await _movementRepository.Add(movement);
            await _movementRepository.Save();
        }
    }
}
