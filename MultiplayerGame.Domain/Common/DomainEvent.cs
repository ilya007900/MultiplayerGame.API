using MediatR;

namespace MultiplayerGame.Domain.Common
{
    public abstract record DomainEvent : INotification;
}
