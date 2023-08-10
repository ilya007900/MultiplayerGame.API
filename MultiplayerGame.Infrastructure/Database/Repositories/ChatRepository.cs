using MultiplayerGame.Domain.Chats;

namespace MultiplayerGame.Infrastructure.Database.Repositories
{
    public class ChatRepository : Repository<Chat, Guid>, IChatRepository
    {
        public ChatRepository(MultiplayerGameDbContext dbContext) : base(dbContext)
        {
        }
    }
}
