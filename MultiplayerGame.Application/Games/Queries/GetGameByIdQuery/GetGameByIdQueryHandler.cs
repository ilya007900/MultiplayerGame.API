using MultiplayerGame.Application.Base;
using MultiplayerGame.Application.Games.Contracts;
using MultiplayerGame.Domain.Games;

namespace MultiplayerGame.Application.Games.Queries.GetGameByIdQuery
{
    public class GetGameByIdQueryHandler : IOperationHandler<GetGameByIdQuery, GameDto>
    {
        private readonly IGameRepository _gameRepository;

        public GetGameByIdQueryHandler(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public async Task<OperationResult<GameDto>> Handle(GetGameByIdQuery request, CancellationToken cancellationToken)
        {
            var game = await _gameRepository.GetById(request.Id, cancellationToken);
            return OperationResultFactory.CreateSucess(Mapper.From(game));
        }
    }
}
