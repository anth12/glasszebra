using System;
using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Extensions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Events;
using MediatR;

namespace CleanArchitecture.Application.Game.Commands.UpdateParticipant
{
	public class UpdateParticipantCommand : IRequest
	{
		public Guid ClientId { get; set; }
		public string Name { get; set; }
		public string Image { get; set; }
	}

	public class UpdateParticipantCommandHandler : IRequestHandler<UpdateParticipantCommand>
	{
		private readonly IApplicationDbContext _context;
		private readonly IMediator _mediator;

		public UpdateParticipantCommandHandler(IApplicationDbContext context, IMediator mediator)
		{
			_context = context;
			_mediator = mediator;
		}

		public async Task<Unit> Handle(UpdateParticipantCommand request, CancellationToken cancellationToken)
		{
			var participant = _context.Participants.FindByClientId(request.ClientId);
			participant.Name = request.Name;
			participant.Image = request.Image;

			await _context.SaveChangesAsync(cancellationToken);

			var @event = new ParticipantUpdatedEvent(false, participant.GameId, participant.Id);
			await _mediator.Publish(@event, cancellationToken);

			return Unit.Value;
		}
	}
}
