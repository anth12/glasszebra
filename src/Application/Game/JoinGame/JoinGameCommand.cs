using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Game.UpdateParticipant;
using CleanArchitecture.Application.Services.Game;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Enums;
using MediatR;

namespace CleanArchitecture.Application.Game.JoinGame
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
			var game = _context.Games.FirstOrDefault(g => g.JoinCode == request.JoinCode);

			if (game == null)
				throw new NotFoundException(nameof(Domain.Entities.Game), request.JoinCode);

			if (game.Status != GameStatus.Lobby)
				throw new InvalidStatusException(game.Status);

			var participantName = _randomNameService.CreateParticipantName();
			var participant = new GameParticipant
			{
				Image = participantName
			};

			game.Participants.Add(participant);

			await _context.SaveChangesAsync(cancellationToken);

			var @event = new ParticipantUpdatedEvent(true, participant.GameId, participant.Id);
			await _mediator.Publish(@event, cancellationToken);
			
			return new JoinGameResponse
			{
				GameClientId = game.ClientId,
				ParticipantClientId = participant.ClientId
			};
		}
	}
}
