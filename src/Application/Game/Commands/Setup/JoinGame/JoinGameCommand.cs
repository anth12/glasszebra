using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GlassZebra.Application.Common.Exceptions;
using GlassZebra.Application.Common.Interfaces;
using GlassZebra.Application.Events;
using GlassZebra.Application.Services.Game;
using GlassZebra.Domain.Entities;
using GlassZebra.Domain.Enums;
using MediatR;

namespace GlassZebra.Application.Game.Commands.Setup.JoinGame
{
	public class JoinGameCommand : IRequest<JoinGameResponse>
	{
		public string JoinCode { get; set; }
	}

	public class JoinGameCommandHandler : IRequestHandler<JoinGameCommand, JoinGameResponse>
	{
		private readonly IApplicationDbContext _context;
		private readonly IMediator _mediator;
		private readonly IRandomNameService _randomNameService;

		public JoinGameCommandHandler(IApplicationDbContext context, IMediator mediator, IRandomNameService randomNameService)
		{
			_context = context;
			_mediator = mediator;
			_randomNameService = randomNameService;
		}

		public async Task<JoinGameResponse> Handle(JoinGameCommand request, CancellationToken cancellationToken)
		{
			var game = _context.Games.First(g => g.JoinCode.Equals(request.JoinCode, StringComparison.InvariantCultureIgnoreCase));
			
			if (game.Status != GameStatus.Lobby)
				throw new InvalidStatusException(game.Status);

			var playerName = _randomNameService.CreatePlayerName();
			var player = new GamePlayer
			{
				Name = playerName
			};

			game.Players.Add(player);

			await _context.SaveChangesAsync(cancellationToken);

			var @event = new PlayerUpdatedEvent(true, player.GameId, player.Id);
			await _mediator.Publish(@event, cancellationToken);
			
			return new JoinGameResponse
			{
				GameClientId = game.ClientId,
				PlayerClientId = player.ClientId,
				PlayerId = player.Id
			};
		}
	}
}
