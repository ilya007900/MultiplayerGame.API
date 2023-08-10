using MultiplayerGame.Application.Chats.Contracts;

namespace MultiplayerGame.Application.Chats.Services
{
    public interface IChatEventsBroker
    {
        Task NotifyMessageSent(Guid chatId, MessageDto message);
    }
}
