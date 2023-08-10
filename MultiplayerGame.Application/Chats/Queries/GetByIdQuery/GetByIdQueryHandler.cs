using MultiplayerGame.Application.Base;
using MultiplayerGame.Application.Chats.Contracts;
using MultiplayerGame.Domain.Chats;

namespace MultiplayerGame.Application.Chats.Queries.GetByIdQuery
{
    public class GetByIdQueryHandler : IOperationHandler<GetByIdQuery, ChatDto>
    {
        private readonly IChatRepository _chatRepository;

        public GetByIdQueryHandler(IChatRepository chatRepository)
        {
            _chatRepository = chatRepository;
        }

        public async Task<OperationResult<ChatDto>> Handle(GetByIdQuery request, CancellationToken cancellationToken)
        {
            var chat = await _chatRepository.GetById(request.ChatId, cancellationToken);
            return OperationResultFactory.CreateSucess(Mapper.From(chat));
        }
    }
}
