using FluentValidation;

namespace CleanArchitecture.Application.Game.JoinGame
{
	public class UpdateParticipantCommandValidator : AbstractValidator<JoinGameCommand>
	{
		public UpdateParticipantCommandValidator()
		{
			RuleFor(v => v.JoinCode)
				.NotEmpty().WithMessage("Join code is missing")
				.MinimumLength(4).WithMessage("Join codes must be at least 4 characters")
				.MaximumLength(10).WithMessage("Join code is too long");
		}

    }
}
