using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Common.Extensions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Events;
using CleanArchitecture.Domain.Enums;
using MediatR;

namespace CleanArchitecture.Application.Game.Commands.UpdateParticipantStatus
{
	public class UpdateParticipantStatusCommand : ParticipantGameCommand, IRequest
	{
		public ParticipantStatus NewStatus { get; set; }
	}

	public class LeaveGameCommandHandler : IRequestHandler<UpdateParticipantStatusCommand>
	{
		private readonly IApplicationDbContext _context;
		private readonly IMediator _mediator;

		public LeaveGameCommandHandler(IApplicationDbContext context, IMediator mediator)
		{
			_context = context;
			_mediator = mediator;
		}

		public async Task<Unit> Handle(UpdateParticipantStatusCommand request, CancellationToken cancellationToken)
		{
			var game = await _context.Games.FindByClientIdAsync(request.GameClientId);
			var participant = game.Participants.FirstOrDefault(p => p.ClientId == request.ParticipantClientId);

			if(participant == null)
				throw new NotFoundException("Participant", request.ParticipantClientId);

			if(participant.Status == request.NewStatus)
				return Unit.Value;
			
			participant.Status = request.NewStatus;

			await _context.SaveChangesAsync(cancellationToken);

			var @event = new ParticipantStatusUpdatedEvent(participant.Status, game.Id, participant.Id);
			await _mediator.Publish(@event, cancellationToken);

			return Unit.Value;
		}
	}
}
