using FluentValidation;

namespace MultiplayerGame.Application.GameRooms.Commands.CreateGameRoomCommand
{
    public class CreateGameRoomCommandValidator : AbstractValidator<CreateGameRoomCommand>
    {
        public CreateGameRoomCommandValidator()
        {
            RuleFor(x => x.Nickname).NotEmpty().MaximumLength(20);
            RuleFor(x => x.Color).NotEmpty().Length(7);
        }
    }
}
