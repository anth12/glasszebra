using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Enums;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Game.Commands.JoinGame
{
	public class UpdatePlayerCommandValidator : AbstractValidator<JoinGameCommand>
	{
		private readonly IApplicationDbContext _context;
		public UpdatePlayerCommandValidator(IApplicationDbContext context)
		{
			_context = context;

			RuleFor(v => v.JoinCode)
				.NotEmpty().WithMessage("Join code is missing")
				.MinimumLength(4).WithMessage("Join codes must be at least 4 characters")
				.MaximumLength(10).WithMessage("Join code is too long")
				.MustAsync(BeValidJoinCode).WithMessage("Game not found")
				.MustAsync(BeJoinable).WithMessage("Game is not in the Lobby & cannot be joined");
		}

		public async Task<bool> BeValidJoinCode(JoinGameCommand model, string joinCode, CancellationToken cancellationToken)
		{
			return await _context.Games
				.AnyAsync(g => g.JoinCode == joinCode, cancellationToken);
		}

		public async Task<bool> BeJoinable(JoinGameCommand model, string joinCode, CancellationToken cancellationToken)
		{
			return await _context.Games
				.AnyAsync(g => g.JoinCode == joinCode && g.Status == GameStatus.Lobby, cancellationToken);
		}
	}
}
