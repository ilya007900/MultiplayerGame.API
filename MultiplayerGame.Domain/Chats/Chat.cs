using MultiplayerGame.Domain.Common;

namespace MultiplayerGame.Domain.Chats
{
    public class Chat : AggregateRoot
    {
        private readonly List<Message> _messages = new();

        public IReadOnlyList<Message> Messages => _messages.OrderBy(x => x.SentDateTime).ToArray();

        private Chat()
        {

        }

        private Chat(Guid id)
        {
            Id = id;
        }

        public static Chat Create()
        {
            return new Chat(Guid.NewGuid());
        }

        public void AddMessage(Message message)
        {
            _messages.Add(message);

            AddDomainEvent(new MessageSentEvent(Id, message));
        }
    }
}
