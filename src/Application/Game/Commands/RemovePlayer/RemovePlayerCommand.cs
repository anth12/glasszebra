using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GlassZebra.Application.Common.Exceptions;
using GlassZebra.Application.Common.Extensions;
using GlassZebra.Application.Common.Interfaces;
using GlassZebra.Application.Events;
using GlassZebra.Domain.Entities;
using GlassZebra.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GlassZebra.Application.Game.Commands.RemovePlayer
{
	public class RemovePlayerCommand : PlayerGameCommand, IRequest
	{
		public int PlayerId { get; set; }
	}

	public class RemovePlayerCommandHandler : IRequestHandler<RemovePlayerCommand>
	{
		private readonly IApplicationDbContext _context;
		private readonly IMediator _mediator;

		public RemovePlayerCommandHandler(IApplicationDbContext context, IMediator mediator)
		{
			_context = context;
			_mediator = mediator;
		}

		public async Task<Unit> Handle(RemovePlayerCommand request, CancellationToken cancellationToken)
		{
			var game = await _context.Games
				.Include(g=> g.Players)
				.Include(g=> g.Categories)
				.FindByClientIdAsync(request.GameClientId);

			var owner = game.Players.FirstOrDefault(p => p.ClientId == request.PlayerClientId);

			if(owner == null || !owner.IsOwner)
				throw new UnauthorizedUpdateException(game.Id, request.PlayerClientId);

			var player = game.Players.FirstOrDefault(p => p.Id == request.PlayerId);

			if(player == null)
				throw new NotFoundException(nameof(GamePlayer), request.PlayerId);

			_context.Players.Remove(player);
			//game.Players.Remove(player); // TODO 

			await _context.SaveChangesAsync(cancellationToken);

			var @event = new PlayerUpdatedEvent(false, game.Id, player.Id);
			await _mediator.Publish(@event, cancellationToken);

			return Unit.Value;
		}
	}
}
