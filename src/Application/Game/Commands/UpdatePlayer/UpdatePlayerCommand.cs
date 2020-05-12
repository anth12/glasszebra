using System;
using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Extensions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Events;
using MediatR;

namespace CleanArchitecture.Application.Game.Commands.UpdatePlayer
{
	public class UpdatePlayerCommand : IRequest
	{
		public Guid ClientId { get; set; }
		public string Name { get; set; }
		public string Image { get; set; }
	}

	public class UpdatePlayerCommandHandler : IRequestHandler<UpdatePlayerCommand>
	{
		private readonly IApplicationDbContext _context;
		private readonly IMediator _mediator;

		public UpdatePlayerCommandHandler(IApplicationDbContext context, IMediator mediator)
		{
			_context = context;
			_mediator = mediator;
		}

		public async Task<Unit> Handle(UpdatePlayerCommand request, CancellationToken cancellationToken)
		{
			var player = _context.Players.FindByClientId(request.ClientId);
			player.Name = request.Name;
			player.Image = request.Image;

			await _context.SaveChangesAsync(cancellationToken);

			var @event = new PlayerUpdatedEvent(false, player.GameId, player.Id);
			await _mediator.Publish(@event, cancellationToken);

			return Unit.Value;
		}
	}
}
