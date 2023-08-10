using Microsoft.AspNetCore.SignalR;
using MultiplayerGame.Application.Chats.Contracts;

namespace MultiplayerGame.Application.Chats.Services
{
    public class ChatEventsBroker : IChatEventsBroker
    {
        private readonly IHubContext<ChatHub> _chatHub;

        public ChatEventsBroker(IHubContext<ChatHub> chatHub)
        {
            _chatHub = chatHub;
        }

        public Task NotifyMessageSent(Guid chatId, MessageDto message)
        {
            return _chatHub.Clients.All.SendAsync($"message-sent-{chatId}", message);
        }
    }
}
