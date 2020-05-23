using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GlassZebra.Application.Common.Exceptions;
using GlassZebra.Application.Common.Extensions;
using GlassZebra.Application.Common.Interfaces;
using GlassZebra.Application.Events;
using GlassZebra.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GlassZebra.Application.Game.Commands.UpdatePlayerStatus
{
	public class UpdatePlayerStatusCommand : PlayerGameCommand, IRequest
	{
		public PlayerStatus NewStatus { get; set; }
	}

	public class UpdatePlayerStatusCommandHandler : IRequestHandler<UpdatePlayerStatusCommand>
	{
		private readonly IApplicationDbContext _context;
		private readonly IMediator _mediator;

		public UpdatePlayerStatusCommandHandler(IApplicationDbContext context, IMediator mediator)
		{
			_context = context;
			_mediator = mediator;
		}

		public async Task<Unit> Handle(UpdatePlayerStatusCommand request, CancellationToken cancellationToken)
		{
			var game = await _context.Games
				.Include(g=> g.Players)
				.FindByClientIdAsync(request.GameClientId);

			var player = game.Players.FirstOrDefault(p => p.ClientId == request.PlayerClientId);

			if(player == null)
				throw new NotFoundException("Player", request.PlayerClientId);

			if(player.Status == request.NewStatus)
				return Unit.Value;
			
			player.Status = request.NewStatus;

			await _context.SaveChangesAsync(cancellationToken);

			var @event = new PlayerUpdatedEvent(false, player.GameId, player.Id);
			await _mediator.Publish(@event, cancellationToken);

			return Unit.Value;
		}
	}
}
