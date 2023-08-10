using MultiplayerGame.Application.Base;
using MultiplayerGame.Application.Chats.Contracts;
using MultiplayerGame.Application.Chats.Services;
using MultiplayerGame.Domain.Chats;

namespace MultiplayerGame.Application.Chats.DomainEventsHandlers
{
    public class MessageSentEventHandler : IDomainEventHandler<MessageSentEvent>
    {
        private readonly IChatEventsBroker _chatEventsBroker;

        public MessageSentEventHandler(IChatEventsBroker chatEventsBroker)
        {
            _chatEventsBroker = chatEventsBroker;
        }

        public async Task Handle(MessageSentEvent notification, CancellationToken cancellationToken)
        {
            await _chatEventsBroker.NotifyMessageSent(notification.ChatId, Mapper.From(notification.Message));
        }
    }
}
