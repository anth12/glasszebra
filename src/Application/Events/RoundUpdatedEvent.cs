using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GlassZebra.Application.Common.Interfaces;
using GlassZebra.Application.Events.Public;
using GlassZebra.Application.Game.Dtos;
using MediatR;

namespace GlassZebra.Application.Events
{
	public class RoundUpdatedEvent : INotification, IPublicEvent
	{
		public RoundUpdatedEvent(bool newRound, int gameId)
		{
			NewRound = newRound;
			GameId = gameId;
		}

		public bool NewRound { get; set; }
		public int GameId { get; }
	}

	public class RoundUpdatedEventHandler : INotificationHandler<RoundUpdatedEvent>
	{
		private readonly IApplicationDbContext _context;
		private readonly IMapper _mapper;
		private readonly IMediator _mediator;

		public RoundUpdatedEventHandler(IApplicationDbContext context, IMapper mapper, IMediator mediator)
		{
			_context = context;
			_mapper = mapper;
			_mediator = mediator;
		}

		public Task Handle(RoundUpdatedEvent notification, CancellationToken cancellationToken)
		{
			var game = _context.Games.Find(notification.GameId);
			var roundDto = game == null ? null : _mapper.Map<GameRoundDto>(game);

			var @event = new RoundUpdatedPublicEvent(notification.NewRound, notification.GameId, roundDto);
			return _mediator.Publish(@event, cancellationToken);
		}
	}
}
