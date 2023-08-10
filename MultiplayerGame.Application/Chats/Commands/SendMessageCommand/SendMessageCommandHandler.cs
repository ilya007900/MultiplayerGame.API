using MultiplayerGame.Application.Base;
using MultiplayerGame.Application.Chats.Contracts;
using MultiplayerGame.Domain.Chats;

namespace MultiplayerGame.Application.Chats.Commands.SendMessageCommand
{
    public sealed record SendMessageCommandHandler : IOperationHandler<SendMessageCommand, ChatDto>
    {
        private readonly IChatRepository _chatRepository;

        public SendMessageCommandHandler(IChatRepository chatRepository)
        {
            _chatRepository = chatRepository;
        }

        public async Task<OperationResult<ChatDto>> Handle(SendMessageCommand request, CancellationToken cancellationToken)
        {
            var chat = await _chatRepository.GetById(request.ChatId);

            var message = Message.Create(request.From, request.Text, DateTimeOffset.Now);

            chat.AddMessage(message);

            return OperationResultFactory.CreateSucess(Mapper.From(chat));
        }
    }
}
