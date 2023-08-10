using MultiplayerGame.Domain.Chats;

namespace MultiplayerGame.Application.Chats.Contracts
{
    public static class Mapper
    {
        public static ChatDto From(Chat chat)
        {
            return new ChatDto(chat.Id, chat.Messages.Select(From).ToArray());
        }

        public static MessageDto From(Message message)
        {
            return new MessageDto(message.Id, message.From, message.Text, message.SentDateTime);
        }
    }
}
