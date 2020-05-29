using System.Threading;
using System.Threading.Tasks;
using GlassZebra.Application.Common.Interfaces;
using GlassZebra.Domain.Enums;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace GlassZebra.Application.Game.Commands.Setup.JoinGame
{
	public class UpdatePlayerCommandValidator : AbstractValidator<JoinGameCommand>
	{
		private const int MaxGamePlayers = 20;

		private readonly IApplicationDbContext _context;
		public UpdatePlayerCommandValidator(IApplicationDbContext context)
		{
			_context = context;

			RuleFor(v => v.JoinCode)
				.NotEmpty().WithMessage("Join code is missing")
				.MinimumLength(4).WithMessage("Join codes must be at least 4 characters")
				.MaximumLength(10).WithMessage("Join code is too long")
				.MustAsync(BeValidJoinCode).WithMessage("Game not found")
				.MustAsync(BeJoinable).WithMessage("Game is not in the Lobby & cannot be joined")
				.MustAsync(BeEmptySeats).WithMessage("Game is full");

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

		public async Task<bool> BeEmptySeats(JoinGameCommand model, string joinCode, CancellationToken cancellationToken)
		{
			var existingPlayerCount = await _context.Players.CountAsync(p=> p.Game.JoinCode == joinCode, cancellationToken);

			return existingPlayerCount <= MaxGamePlayers;
		}
	}
}
