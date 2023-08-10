using MediatR;

namespace MultiplayerGame.Application.Base
{
    public interface IDomainEventHandler<TNotificaion> : INotificationHandler<TNotificaion>
        where TNotificaion : INotification
    {
    }
}
