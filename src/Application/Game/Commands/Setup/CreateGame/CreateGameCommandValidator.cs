using FluentValidation;

namespace GlassZebra.Application.Game.Commands.Setup.CreateGame
{
	public class CreateGameCommandValidator : AbstractValidator<CreateGameCommand>
	{
		public CreateGameCommandValidator()
		{
			RuleFor(v => v.Name)
				.NotEmpty().WithMessage("Name must not be empty")
				.Length(3, 55).WithMessage("Name must be between 3 & 55 characters");
		}
	}
}
