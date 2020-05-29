using FluentValidation;

namespace GlassZebra.Application.Game.Commands.Setup.UpdateGame
{
	public class UpdateGameCommandValidator : AbstractValidator<UpdateGameCommand>
	{
		public UpdateGameCommandValidator()
		{
			CascadeMode = CascadeMode.StopOnFirstFailure;

			RuleFor(v => v.Name)
				.NotEmpty().WithMessage("Name must not be empty")
				.Length(3, 55).WithMessage("Name must be between 3 & 55 characters");

			RuleFor(v => v.QuestionsPerRound)
				.GreaterThan(0).WithMessage("Each round must have at least 1 question")
				.LessThan(Domain.Entities.Game.MaxQuestionsPerRound).WithMessage("Rounds cannot exceed 99 questions");

			RuleFor(v => v.NumberOfRounds)
				.GreaterThan(0).WithMessage("You must have at least 1 round")
				.LessThan(Domain.Entities.Game.MaxNumberOfRounds).WithMessage("Games cannot exceed 99 rounds");

			RuleFor(v => v.Difficulty)
				.NotEmpty();

			RuleFor(v => v.Categories)
				.NotNull()
				.Must(c=> c.Count <= 20)
				.WithMessage("Categories cannot exceed 20")
				.Must(c => c.Count > 0)
				.WithMessage("You need at least 1 Category"); ;
		}
	}
}
